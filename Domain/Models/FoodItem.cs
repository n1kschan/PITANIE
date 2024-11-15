using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class FoodItem
    {
        public FoodItem()
        {
            FoodAllergens = new HashSet<FoodAllergen>();
            FoodItemCategories = new HashSet<FoodItemCategory>();
            MealFoodItems = new HashSet<MealFoodItem>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
            ShoppingListItems = new HashSet<ShoppingListItem>();
        }

        public int FoodItemId { get; set; }
        public string FoodName { get; set; } = null!;
        public int? Calories { get; set; }
        public decimal? Protein { get; set; }
        public decimal? Carbohydrates { get; set; }
        public decimal? Fats { get; set; }

        public virtual ICollection<FoodAllergen> FoodAllergens { get; set; }
        public virtual ICollection<FoodItemCategory> FoodItemCategories { get; set; }
        public virtual ICollection<MealFoodItem> MealFoodItems { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
