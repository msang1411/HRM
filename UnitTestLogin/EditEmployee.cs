using NUnit.Framework;
using HRM.Services;
using HRM.Models;
using System;
/*using Microsoft.VisualStudio.TestTools.UnitTesting;*/

namespace UnitTestLogin
{
    public class TestsEditEmployee
    {
        private EmployeeServices employeeServices;
        private Employee employee;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEditSusscess()
        {
            employeeServices = new EmployeeServices();
            employee = new Employee();
            employee.Birth = new System.DateTime(2021, 2, 2);
            employee.DepartmentId = 1;
            employee.PositionId = 1;
            employee.Email = "emailok";
            employee.Gender = "nam";
            employee.Name = "Pham Minh Sang";
            employee.PhoneNumber = 9977666777;
            employee.Wage = 30000;
            bool actual = employeeServices.EditEmployee(employee);
            NUnit.Framework.Assert.AreEqual(true, actual);
        }
        [Test]
        public void TestEditWithoutEmail()
        {
            employeeServices = new EmployeeServices();
            employee = new Employee();
            employee.Birth = new System.DateTime(2021, 2, 2);
            employee.DepartmentId = 1;
            employee.PositionId = 1;
            employee.Email = "";
            employee.Gender = "nam";
            employee.Name = "Pham Minh Sang";
            employee.PhoneNumber = 9977666777;
            employee.Wage = 30000;
            bool actual = employeeServices.EditEmployee(employee);
            NUnit.Framework.Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestEditWithoutPhoneNumber()
        {
            employeeServices = new EmployeeServices();
            employee = new Employee();
            employee.Birth = new System.DateTime(2021, 2, 2);
            employee.DepartmentId = 1;
            employee.PositionId = 1;
            employee.Email = "emailok";
            employee.Gender = "nam";
            employee.Name = "Pham Minh Sang";
            employee.PhoneNumber = 0;
            employee.Wage = 30000;
            bool actual = employeeServices.EditEmployee(employee);
            NUnit.Framework.Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestPhoneNumberIsNull()
        {
            employeeServices = new EmployeeServices();
            employee = new Employee();
            employee.Birth = new System.DateTime(2021, 2, 2);
            employee.DepartmentId = 1;
            employee.PositionId = 1;
            employee.Email = "emailok";
            employee.Gender = "nam";
            employee.Name = "Pham Minh Sang";
            employee.PhoneNumber = null;
            employee.Wage = 30000;
            bool actual = employeeServices.EditEmployee(employee);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void TestWageIsNull()
        {
            employeeServices = new EmployeeServices();
            employee = new Employee();
            employee.Birth = new System.DateTime(2021, 2, 2);
            employee.DepartmentId = 1;
            employee.PositionId = 1;
            employee.Email = "emailok";
            employee.Gender = "nam";
            employee.Name = "Pham Minh Sang";
            employee.PhoneNumber = 123456789;
            employee.Wage = null;
            bool actual = employeeServices.EditEmployee(employee);
            Assert.AreEqual(false, actual);
        }
    }
}
