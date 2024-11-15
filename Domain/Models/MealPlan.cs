using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MealPlan
    {
        public MealPlan()
        {
            Meals = new HashSet<Meal>();
        }

        public int MealPlanId { get; set; }
        public int? UserId { get; set; }
        public string? PlanName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
