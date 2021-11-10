using HRM.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class AuthenticationService
    {
        readonly AuthenticationStateProvider _authenticationStateProvider;
        readonly IDbContextFactory<HRMContext> _contextFactory;
        int _currentEmployeeId;
        public AuthenticationService(IDbContextFactory<HRMContext> contextFactory, AuthenticationStateProvider authenticationStateProvider)
        {
            _contextFactory = contextFactory;
            _authenticationStateProvider = authenticationStateProvider;
        }
        string GetCurrentUserEmail()
        {
            var authState = _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.Result.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public Account GetCurrentAccount()
        {
            var account = GetCurrentAccount();
            using var context = _contextFactory.CreateDbContext();
            return context.Accounts.FirstOrDefault(f => f.Account1.Equals(account));
        }
        public async Task<int> GetCurrentEmployeeId()
        {
            var account = GetCurrentAccount();
            if (_currentEmployeeId == 0)
            {
                using var context = _contextFactory.CreateDbContext();
                var temp = await context.Accounts.FirstAsync(f => f.Account1.Equals(account));
                if (temp != null)
                {
                    _currentEmployeeId = (int)temp.EmployeeId;
                    return _currentEmployeeId;
                }
                else
                    throw new Exception("Employee Not Found");
            }
            else
            {
                return _currentEmployeeId;
            }
        }
    }
}
