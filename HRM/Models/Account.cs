using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Account
    {
        public string AccountEmployee { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
