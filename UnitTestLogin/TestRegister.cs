using NUnit.Framework;
using HRM.Services;
using HRM.Models;

namespace UnitTestLogin
{
    public class TestRegister
    {
        private AccountServices accountServices;
        private Account account;
        private string confirmAccount = "";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAccountInvalid()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public void TestConfirmPasswordWrong()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "sang3333";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestEmptyAccount()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestAccountIllegal()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "ad";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestSameAccount()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email11";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestPasswordIllegal()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestEmptyPassword()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "";
            account.EmployeeId = 1;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestEmptyEmployeeId()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang1411";
            account.EmployeeId = 0;
            account.Role = "admin";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestEmptyRole()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            account.Role = "";
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
        public void TestNullRole()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email33";
            account.Password = "Sang1411";
            account.EmployeeId = 1;
            confirmAccount = "Sang1411";
            bool actual = accountServices.AddAccount(account, confirmAccount);
            Assert.AreEqual(false, actual);
        }
    }
}
