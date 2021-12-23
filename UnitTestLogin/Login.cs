using NUnit.Framework;
using HRM.Services;
using HRM.Models;

namespace UnitTestLogin
{
    public class TestsLogin
    {
        private AccountServices accountServices;
        private Account account;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckAccountInvalid()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email11";
            account.Password = "Sang1411";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public void CheckAccountWithPasswordIllegal()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email11";
            account.Password = "1234";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void CheckAccountWithEmailIllegal()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email";
            account.Password = "Sang1411";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void CheckAccountWithWrongEmail()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email111";
            account.Password = "Sang1411";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void CheckAccountWithWrongPassword()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email11";
            account.Password = "Sang14111";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void CheckAccountWithDontEnterPassword()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "email11";
            account.Password = "";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void CheckAccountWithDontEnterEmail()
        {
            accountServices = new AccountServices();
            account = new Account();
            account.Account1 = "";
            account.Password = "Sang14111";
            bool actual = accountServices.CheckAccount(account);
            Assert.AreEqual(false, actual);
        }
    }
}