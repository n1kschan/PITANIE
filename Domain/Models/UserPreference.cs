using System;
using System.Collections.Generic;
    
namespace Domain.Models
{   
    public partial class UserPreference
    {
        public int UserPreferenceId { get; set; }
        public int? UserId { get; set; }
        public string? PreferenceName { get; set; }
        public string? PreferenceValue { get; set; }

        public virtual User? User { get; set; }
    }
}
