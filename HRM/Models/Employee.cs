using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            Assessments = new HashSet<Assessment>();
            CalendarDetails = new HashSet<CalendarDetail>();
            LeaveApplicationApproverNavigations = new HashSet<LeaveApplication>();
            LeaveApplicationEmployees = new HashSet<LeaveApplication>();
            Recruitments = new HashSet<Recruitment>();
            SalaryDetails = new HashSet<SalaryDetail>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? Wage { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? IsInternship { get; set; } = false;
        public DateTime? JoinInternshipDate { get; set; }
        public string StateInternship { get; set; }
        public int? ApproverInternship { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<CalendarDetail> CalendarDetails { get; set; }
        public virtual ICollection<LeaveApplication> LeaveApplicationApproverNavigations { get; set; }
        public virtual ICollection<LeaveApplication> LeaveApplicationEmployees { get; set; }
        public virtual ICollection<Recruitment> Recruitments { get; set; }
        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }
    }
}
