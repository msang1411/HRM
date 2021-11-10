using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class AccountService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public AccountService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(Account account)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Accounts.Add(account);
            await context.SaveChangesAsync();
        }
    }
}
