using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Salary
    {
        public Salary()
        {
            SalaryDetails = new HashSet<SalaryDetail>();
        }

        public string SalaryId { get; set; }
        public decimal? TotalSalary { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }

        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }
    }
}
