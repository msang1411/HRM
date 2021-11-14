using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class SalaryService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public SalaryService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Salary GetSalary(string salaryId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Salaries.Where(n => n.SalaryId.Equals(salaryId)).FirstOrDefault();
        }

        public void AddSalary(string salaryId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            Salary salary = new Salary();

            salary.SalaryId = salaryId;
            salary.CreateAt = DateTime.Now;
            salary.IsPaid = false;

            context.Salaries.Add(salary);
            context.SaveChanges();

            SalaryDetailService salaryDetailService = new SalaryDetailService(_dbContextFactory);
            EmployeeService employeeService = new EmployeeService(_dbContextFactory);

            SalaryDetail salaryDetail = new SalaryDetail();
            salaryDetail.SalaryId = salaryId;
            salaryDetail.EmployeeId = int.Parse(salaryId.Split("-")[0]);
            salaryDetail.CreateAt = DateTime.Now;
            salaryDetail.Salary = employeeService.GetEmployee(int.Parse(salaryId.Split("-")[0])).Wage;
            salaryDetail.Content = "Lương cơ bản tháng " + salaryId.Split("-")[2] + " năm " + salaryId.Split("-")[1];

            salaryDetailService.AddSalaryDetails(salaryDetail);
        }

        public void UpdateTotalSalary(string salaryId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            SalaryDetailService salaryDetailService = new SalaryDetailService(_dbContextFactory);

            List<SalaryDetail> salaryDetails = salaryDetailService.GetSalaryDetails(salaryId);
            Salary salary = context.Salaries.Where(x => x.SalaryId.Equals(salaryId))
                                            .FirstOrDefault();
                salary.TotalSalary = 0;
            foreach (SalaryDetail salaryDetail in salaryDetails)
            {
                salary.TotalSalary += salaryDetail.Salary;
            }
            context.Salaries.Update(salary);
            context.SaveChanges();
        }
    }
}
