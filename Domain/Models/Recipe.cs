using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            FavoriteRecipes = new HashSet<FavoriteRecipe>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int RecipeId { get; set; }
        public string? RecipeName { get; set; }
        public int? PreparationTime { get; set; }
        public int? CookingTime { get; set; }
        public string? Instructions { get; set; }

        public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
