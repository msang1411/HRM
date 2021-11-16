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

        public void UpdateCalendarDetail(CalendarDetail calendarDetail)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.CalendarDetails.Update(calendarDetail);
            context.SaveChanges();
        }

        public CalendarDetail GetCalendarOnDay(string calendarId, int day, int shift)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.CalendarDetails.Where(x => x.CalendarId.Equals(calendarId) && x.Day == day && x.Shift == shift)
                                          .FirstOrDefault();
        }

        public void OnShift(CalendarDetail calendarDetail)
        {
            using var context = _dbContextFactory.CreateDbContext();
            calendarDetail.ActualStart = DateTime.Now.TimeOfDay;
            calendarDetail.IsAttendance = true;
            context.CalendarDetails.Update(calendarDetail);
            context.SaveChanges();
        }

        public void BrowseShift(string calendarId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            int day = DateTime.Now.Day;

            List<CalendarDetail> calendarDetailsIsWork = context.CalendarDetails.Where(x => x.CalendarId.Equals(calendarId) &&
                                                                                            x.Day < day &&
                                                                                            x.IsWork == true &&
                                                                                            x.IsAttendance == null)
                                                                                .ToList();
            foreach(CalendarDetail calendarDetail in calendarDetailsIsWork)
            {
                calendarDetail.IsAttendance = false;
                context.CalendarDetails.Update(calendarDetail);
            }
            context.SaveChanges();
            if (DateTime.Now.TimeOfDay >= new TimeSpan(14, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(18, 0, 0))
            {
                if (GetCalendarOnDay(calendarId, day, 1).IsAttendance == null)
                {
                    CalendarDetail calendar = new CalendarDetail();
                    calendar = GetCalendarOnDay(calendarId, day, 1);
                    calendar.IsAttendance = false;
                    context.CalendarDetails.Update(calendar);
                    context.SaveChanges();
                }
            }
            else if (DateTime.Now.TimeOfDay >= new TimeSpan(19, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(21, 0, 0))
            {
                for (int shift = 1; shift <= 2; shift++)
                {
                    if (GetCalendarOnDay(calendarId, day, shift).IsAttendance == null)
                    {
                        CalendarDetail calendar = new CalendarDetail();
                        calendar = GetCalendarOnDay(calendarId, day, shift);
                        calendar.IsAttendance = false;
                        context.CalendarDetails.Update(calendar);
                        context.SaveChanges();
                    }
                }
            }
            else if (DateTime.Now.TimeOfDay >= new TimeSpan(21, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(23, 55, 55))
            {
                for (int shift = 1; shift <= 3; shift++)
                {
                    if (GetCalendarOnDay(calendarId, day, shift).IsAttendance == null)
                    {
                        CalendarDetail calendar = new CalendarDetail();
                        calendar = GetCalendarOnDay(calendarId, day, shift);
                        calendar.IsAttendance = false;
                        context.CalendarDetails.Update(calendar);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
