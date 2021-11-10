using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Account
    {
        public string Account1 { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }
        public string Role { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
