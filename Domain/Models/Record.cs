using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public int? UserId { get; set; }
        public int? ActivityId { get; set; }
        public DateTime? RecordDate { get; set; }

        public virtual Activity? Activity { get; set; }
        public virtual User? User { get; set; }
    }
}
