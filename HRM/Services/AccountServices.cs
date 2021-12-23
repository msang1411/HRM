using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class AccountServices
    {
        List<Account> accounts;
        public AccountServices()
        {
            accounts = new List<Account>();
            Account acc = new Account 
            { 
                Account1 = "email11",
                EmployeeId = 1,
                Password = "Sang1411",
                Role = "admin"
            };

            accounts.Add(acc);
            acc = new Account
            {
                Account1 = "email22",
                EmployeeId = 2,
                Password = "1411Sang",
                Role = "user"
            };
            accounts.Add(acc);
        }
        public bool CheckAccount(Account account)
        {
            if (account.Password.Length < 6 ||
                account.Password.Length == 0 ||
                account.Password == null ||
                account.Account1.Length < 6 ||
                account.Account1.Length == 0 ||
                account.Account1 == null)
            {
                return false;
            }
            else
            {
                if (accounts.Where(x => x.Account1 == account.Account1 && x.Password == account.Password)
                            .Count() == 0)
                {
                    return false;
                }
                return true;
            }
        }
        public bool AddAccount(Account account, string comfirmPassword)
        {
            if (account.Account1 == null ||
                account.Account1 == "" ||
                account.Account1.Length < 6 ||
                account.EmployeeId == 0 ||
                account.Password == null ||
                account.Password == "" ||
                account.Password.Length < 6 ||
                comfirmPassword.Equals(account.Password) == false ||
                account.Role == null ||
                account.Role ==  "")
            {
                return false;
            }
            else
            {
                if (accounts.Where(x => x.Account1 == account.Account1)
                            .Count() != 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
