using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class NotificationService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public NotificationService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void CreateNotification(Notification notification)
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context.Notifications.Where(x => x.DepartmentId == notification.DepartmentId).Count() == 0)
            {
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }

        public Notification GetNotification(int departmentId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Notifications.Where(x => x.DepartmentId == departmentId).FirstOrDefault();
        }

        public void Update(Notification notification)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Notifications.Update(notification);
            context.SaveChanges();
        }
    }
}
