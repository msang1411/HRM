using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class AssessmentType
    {
        public AssessmentType()
        {
            Assessments = new HashSet<Assessment>();
        }

        public int AssessmentTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
