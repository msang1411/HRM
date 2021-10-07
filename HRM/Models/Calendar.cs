using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Calendar
    {
        public Calendar()
        {
            CalendarDetails = new HashSet<CalendarDetail>();
        }

        public string CalendarId { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

        public virtual ICollection<CalendarDetail> CalendarDetails { get; set; }
    }
}
