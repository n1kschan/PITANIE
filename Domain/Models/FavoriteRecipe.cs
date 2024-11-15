using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class FavoriteRecipe
    {
        public int FavoriteRecipeId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe? Recipe { get; set; }
        public virtual User? User { get; set; }
    }
}
