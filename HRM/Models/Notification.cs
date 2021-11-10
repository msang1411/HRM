using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Notification
    {
        public DateTime CreateAt { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
