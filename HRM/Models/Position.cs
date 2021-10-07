using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
            Recruitments = new HashSet<Recruitment>();
        }

        public int PositionId { get; set; }
        public string Name { get; set; }
        public decimal? AverageWage { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Recruitment> Recruitments { get; set; }
    }
}
