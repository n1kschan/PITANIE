using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Allergen
    {
        public Allergen()
        {
            FoodAllergens = new HashSet<FoodAllergen>();
        }

        public int AllergenId { get; set; }
        public string AllergenName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<FoodAllergen> FoodAllergens { get; set; }
    }
}
