using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class CalendarDetailService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public CalendarDetailService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<CalendarDetail> GetCalendarDetails(string calendarId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.CalendarDetails.Where(x => x.CalendarId.Equals(calendarId)).OrderBy(x => x.Day).ToList();
        }

        public void AddCalendarDetailsFullMonth(string calendarId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int employeeId = int.Parse(calendarId.Split("-")[0]);
            int numberDayInMonth = DateTime.DaysInMonth(int.Parse(calendarId.Split("-")[1]), int.Parse(calendarId.Split("-")[2]));

            for (int day = 1; day <= numberDayInMonth; day++)
            {
                for (int shift = 1; shift <= 3; shift++)
                {
                    CalendarDetail calendarDetail = new CalendarDetail();
                    calendarDetail.CalendarId = calendarId;
                    calendarDetail.EmployeeId = employeeId;
                    calendarDetail.Day = day;
                    calendarDetail.Shift = shift;
                    calendarDetail.IsAttendance = false;
                    calendarDetail.IsLeavePermission = false;
                    calendarDetail.IsWork = false;

                    context.CalendarDetails.Add(calendarDetail);
                }
            }
            context.SaveChanges();
        }

        public void UpdateCalendar(List<CalendarDetail> listCalendarDetails)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.CalendarDetails.UpdateRange(listCalendarDetails);
            context.SaveChanges();
        }
    }
}
