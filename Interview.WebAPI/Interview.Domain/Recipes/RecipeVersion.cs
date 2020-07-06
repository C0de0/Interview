using Interview.Domain.Countries;
using System;

namespace Interview.Domain.Recipes
{
    public class RecipeVersion : IEntity
    {
        public long RecipeVersionId { get; set; }
        public long RecipeId { get; set; }
        public bool IsVerified { get; set; }
        public int? VerifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedByUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedByUserId { get; set; }
        public Country Language { get; set; } // simplified for now - separate Language class should be used to accomodate all cases
        public RecipeContent Content { get; set; }
    }
}
