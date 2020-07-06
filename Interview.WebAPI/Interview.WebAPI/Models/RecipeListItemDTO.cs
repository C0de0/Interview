using System;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.WebAPI.Models
{
    public class RecipeListItemDTO
    {
        public long RecipeId { get; set; }
        public long RecipeVersionId { get; set; }
        public string RecipeName { get; set; }
        public string Language { get; set; }
    }
}
