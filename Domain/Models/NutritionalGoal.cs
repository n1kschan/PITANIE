using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class NutritionalGoal
    {
        public int GoalId { get; set; }
        public int? UserId { get; set; }
        public int? DailyCaloricIntake { get; set; }
        public decimal? ProteinGoal { get; set; }
        public decimal? CarbohydrateGoal { get; set; }
        public decimal? FatGoal { get; set; }

        public virtual User? User { get; set; }
    }
}
