using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MealFoodItem
    {
        public int MealFoodItemId { get; set; }
        public int? MealId { get; set; }
        public int? FoodItemId { get; set; }
        public decimal? ServingSize { get; set; }

        public virtual FoodItem? FoodItem { get; set; }
        public virtual Meal? Meal { get; set; }
    }
}
