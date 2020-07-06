using System.Collections.Generic;

namespace Interview.WebAPI.Models
{
    public class RecipeDetailsDTO
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public List<RecipeDescriptionSectionDTO> Sections { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
