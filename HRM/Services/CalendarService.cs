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

        public Calendar GetCalendar(string calendarId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Calendars.Where(n => n.CalendarId.Equals(calendarId)).FirstOrDefault();
        }

        public void AddCalendar(Calendar calendar)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Calendars.Add(calendar);
            CalendarDetailService calendarDetailService = new CalendarDetailService(_dbContextFactory);
            context.SaveChanges();
            calendarDetailService.AddCalendarDetailsFullMonth(calendar.CalendarId);
            
        }
    }
}
