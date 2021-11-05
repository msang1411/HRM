using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class CalendarService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public CalendarService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
