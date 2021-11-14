using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class SalaryDetailService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public SalaryDetailService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<SalaryDetail> GetSalaryDetails(string salaryId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.SalaryDetails.Where(x => x.SalaryId.Equals(salaryId)).ToList();
        }

        public void AddSalaryDetails(SalaryDetail salaryDetail)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.SalaryDetails.Add(salaryDetail);
            context.SaveChanges();
        }

        public void Update(SalaryDetail salaryDetail)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.SalaryDetails.Update(salaryDetail);
            context.SaveChanges();
        }
    }
}