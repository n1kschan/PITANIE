using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealFoodItems = new HashSet<MealFoodItem>();
        }

        public int MealId { get; set; }
        public int? MealPlanId { get; set; }
        public string? MealType { get; set; }
        public DateTime? MealDate { get; set; }

        public virtual MealPlan? MealPlan { get; set; }
        public virtual ICollection<MealFoodItem> MealFoodItems { get; set; }
    }
}
