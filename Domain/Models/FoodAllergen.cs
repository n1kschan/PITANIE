using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class FoodAllergen
    {
        public int FoodAllergenId { get; set; }
        public int FoodItemId { get; set; }
        public int AllergenId { get; set; }

        public virtual Allergen? Allergen { get; set; }
        public virtual FoodItem? FoodItem { get; set; }
    }
}
