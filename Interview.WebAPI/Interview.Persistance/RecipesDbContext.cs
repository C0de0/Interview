using Interview.Domain.Recipes;
using Interview.Domain.Users;
using Interview.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Interview.Persistance
{
    public class RecipesDbContext : DbContext
    {
        private readonly ILogger<RecipesDbContext> _logger;

        public RecipesDbContext(ILogger<RecipesDbContext> logger)
        {
            _logger = Assert.NotNull(nameof(logger), logger);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RecipeVersion> RecipeVersions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TODO: mapping between Domain objects and DB
            base.OnModelCreating(modelBuilder);
        }
    }
}
