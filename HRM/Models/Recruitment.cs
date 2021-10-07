using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Recruitment
    {
        public int RecruitmentId { get; set; }
        public string SrcFile { get; set; }
        public DateTime? SubmissionAt { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Approver { get; set; }
        public int? AppliedPosition { get; set; }

        public virtual Position AppliedPositionNavigation { get; set; }
        public virtual Employee ApproverNavigation { get; set; }
    }
}
