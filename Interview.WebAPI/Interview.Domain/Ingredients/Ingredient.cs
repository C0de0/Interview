using Interview.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Domain.Ingredients
{
    public class Ingredient
    {
        // TODO: will require some way to group same ingredient's versions in different languages
        public int IngredientId { get; set; }
        public string Name { get; set; }
    }
}
