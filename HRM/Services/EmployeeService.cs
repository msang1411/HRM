using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class EmployeeService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public EmployeeService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddEmployee(Employee employee)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
        }
    }
}
