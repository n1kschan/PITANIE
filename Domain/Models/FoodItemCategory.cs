using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class FoodItemCategory
    {
        public int FoodItemCategoryId { get; set; }
        public int FoodItemId { get; set; }
        public int FoodCategoryId { get; set; }

        public virtual FoodCategory? FoodCategory { get; set; }
        public virtual FoodItem? FoodItem { get; set; }
    }
}
