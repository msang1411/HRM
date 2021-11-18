using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class LeaveApplicationService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public LeaveApplicationService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Add(LeaveApplication leaveApplication)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Add(leaveApplication);
            context.SaveChanges();
        }

        public void Approved(LeaveApplication leaveApplication, string calendarId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            CalendarDetailService calendarDetailService = new CalendarDetailService(_dbContextFactory);
            string[] arrDateTime = leaveApplication.Day.ToString().Split(" ");
            string[] arrDate = arrDateTime[0].Split("/");
            CalendarDetail calendarDetail = calendarDetailService.GetCalendarOnDay(calendarId,
                                                                                   int.Parse(arrDate[1]),
                                                                                   (int)leaveApplication.Shift);
            calendarDetail.IsLeavePermission = leaveApplication.IsApproved;
            leaveApplication.ApprovedAt = DateTime.Now;
            calendarDetailService.UpdateCalendarDetail(calendarDetail);
            context.Update(leaveApplication);
            context.SaveChanges();
        }

        public List<LeaveApplication> GetNotApprovedYet()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.LeaveApplications.Where(x => x.IsApproved == null).ToList();
        }
    }
}
