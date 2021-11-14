using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class SalaryDetail
    {
        public int EmployeeId { get; set; }
        public string SalaryId { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal? Salary { get; set; }
        public string Content { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Salary SalaryNavigation { get; set; }
    }
}
