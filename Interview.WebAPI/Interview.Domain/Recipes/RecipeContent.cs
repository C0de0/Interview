using Interview.Domain.Countries;
using Interview.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Recipes
{
    public class RecipeContent
    {
        public string Name { get; set; }
        public List<DescriptionSection> Description { get; set; }
        public Country CountryOfOrigin { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
