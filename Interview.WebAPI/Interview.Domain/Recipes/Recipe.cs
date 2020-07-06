using Interview.Domain.Countries;
using Interview.Domain.Ingredients;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Recipes
{
    public class Recipe : IEntity
    {
        public long RecipeId { get; set; }
    }
}
