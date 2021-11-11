using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class CalendarDetail
    {
        public int EmployeeId { get; set; }
        public string CalendarId { get; set; }
        public int Shift { get; set; }
        public int Day { get; set; }
        public bool? IsAttendance { get; set; }
        public bool? IsLeavePermission { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }
        public TimeSpan? ActualStart { get; set; }
        public TimeSpan? ActualEnd { get; set; }
        public bool? IsOvertime { get; set; }
        public bool? IsWork { get; set; }

        public virtual Calendar Calendar { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
