using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Assessment
    {
        public int EmployeeId { get; set; }
        public DateTime CreateAt { get; set; }
        public string SrcFile { get; set; }
        public string Content { get; set; }
        public int? AssessmentType { get; set; }

        public virtual AssessmentType AssessmentTypeNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
