using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Areas.Identity.Data
{
    public class HRMUser : IdentityUser
    {
        public bool IsEnabled { get; set; }
    }
}
