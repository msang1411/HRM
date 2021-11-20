using System;
using System.Collections.Generic;

#nullable disable

namespace HRM.Models
{
    public partial class Notification
    {
        public int DepartmentId { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual Department Department { get; set; }
    }
}
