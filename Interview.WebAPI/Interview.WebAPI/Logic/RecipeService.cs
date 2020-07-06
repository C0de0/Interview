using Interview.Domain.Recipes;
using Interview.Domain.Users;
using Interview.Persistance;
using Interview.Utilities;
using Interview.WebAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Interview.WebAPI.Logic
{
    public class RecipeService
    {
        private readonly ILogger<RecipeService> _logger;
        private readonly IPermissionService _permissionService;
        private readonly UserData _userData;
        private readonly IRecipesDbContextProvider _ctxProvider;

        public RecipeService(ILogger<RecipeService> logger, IPermissionService permissionService, UserData userData, IRecipesDbContextProvider ctxProvider)
        {
            _logger = Assert.NotNull(nameof(logger), logger);
            _permissionService = Assert.NotNull(nameof(permissionService), permissionService);
            _userData = Assert.NotNull(nameof(userData), userData); // TODO: IPermissionService could ask for userData instead of RecipeService
            _ctxProvider = Assert.NotNull(nameof(ctxProvider), ctxProvider);
        }

        public async Task<List<RecipeListItemDTO>> RecipeList()
        {
            var isAllowed = _permissionService.IsAllowed(Permission.GetRecipes, _userData.ToUser()); // AutoMapper here 
            if (!isAllowed)
                throw new SecurityException($"User {_userData} is not allowed to {nameof(Permission.GetRecipes)}");
            // TODO: add helper method to IPermissionService (called EnsureIsAllowed?) that will combine the 3 lines above

            List<RecipeListItemDTO> result = null;
            using (var ctx = _ctxProvider.New())
            {
                var query = 
                    from rv in ctx.RecipeVersions
                    where !rv.IsDeleted
                        && rv.IsVerified
                    group rv by rv.RecipeId into g
                    select new
                    {
                        recipeId = g.Key,
                        firstRow = g.OrderBy(x => x.DateCreated).First()
                    };

                result = await query
                    .Select(x => new RecipeListItemDTO
                    {
                        RecipeId = x.recipeId,
                        RecipeVersionId = x.firstRow.RecipeVersionId,
                        RecipeName = x.firstRow.Content.Name,
                        Language = x.firstRow.Language.Name,
                    })
                    .ToListAsync();
                
                // TODO: The approach above will obviously not work. There will need to be a separation between domain and db model 
            }

            return result;
        }

        public RecipeListItemDTO GetRecipe(long recipeId)
        {
            var isAllowed = _permissionService.IsAllowed(Permission.GetRecipes, _userData.ToUser()); // AutoMapper here 
            if (!isAllowed)
                throw new SecurityException($"User {_userData} is not allowed to {nameof(Permission.GetRecipes)}");
            // TODO: add helper method to IPermissionService (called EnsureIsAllowed?) that will combine the 3 lines above

            RecipeListItemDTO result = null;
            using (var ctx = _ctxProvider.New())
            {
                var item =
                    (from rv in ctx.RecipeVersions
                    where !rv.IsDeleted
                        && rv.IsVerified
                        && rv.RecipeId == recipeId
                    orderby rv.DateCreated descending
                    select rv).FirstOrDefault();

                result = item == null ? null : new
                    RecipeListItemDTO
                    {
                        RecipeId = item.RecipeId,
                        RecipeVersionId = item.RecipeVersionId,
                        RecipeName = item.Content.Name,
                        Language = item.Language.Name,
                    };

                // TODO: The approach above will obviously not work. There will need to be a separation between domain and db model 
            }

            return result;
        }
    }

}
