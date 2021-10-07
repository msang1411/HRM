using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class LeaveApplication
    {
        public int EmployeeId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Reason { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public int? Approver { get; set; }

        public virtual Employee ApproverNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
