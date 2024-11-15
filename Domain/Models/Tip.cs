using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Tip
    {
        public int TipId { get; set; }
        public int? UserId { get; set; }
        public string? TipText { get; set; }
        public string? Category { get; set; }

        public virtual User? User { get; set; }
    }
}
