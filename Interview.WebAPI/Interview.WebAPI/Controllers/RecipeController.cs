using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Utilities;
using Interview.WebAPI.Logic;
using Interview.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interview.WebAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    ///
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, RecipeService recipeService)
        {
            _logger = Assert.NotNull(nameof(logger), logger);
            _recipeService = Assert.NotNull(nameof(recipeService), recipeService);
        }

        /// <summary>
        /// Gets a list of all recipes existing in the system. Returns latest verified recipes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeListItemDTO>>> GetRecipes()
        {
            var recipes = await _recipeService.RecipeList(); 

            return recipes;
        }


        [HttpGet("{recipeId}")]
        public async Task<ActionResult<RecipeListItemDTO>> GetRecipe(long recipeId)
        {
            var recipe = _recipeService.GetRecipe(recipeId);

            return recipe;
        }

        [HttpPut("{recipeId}")]
        public async Task<IActionResult> UpdateRecipe(long recipeId, RecipeListItemDTO recipeListItemDTO)
        {
            // will not be creating / updating "list" items, move it to "details" controller / methods
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<RecipeListItemDTO>> CreateRecipe(RecipeListItemDTO recipeListItemDTO)
        {
            // will not be creating / updating "list" items, move it to "details" controller / methods
            throw new NotImplementedException();
        }
    }
}
