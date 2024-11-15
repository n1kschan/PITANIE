using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Records = new HashSet<Record>();
        }

        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string ActivityName { get; set; } = null!;
        public int CaloriesBurned { get; set; }
        public int Duration { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
