using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? Gender { get; set; }

        public virtual User? User { get; set; }
    }
}
