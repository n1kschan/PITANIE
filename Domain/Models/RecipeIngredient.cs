using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int? RecipeId { get; set; }
        public int? FoodItemId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual FoodItem? FoodItem { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
