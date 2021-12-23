using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class EmployeeServices
    {
        public bool EditEmployee(Employee employee)
        {
            if (employee.Birth == null ||
                employee.DepartmentId == null ||
                employee.Email == null ||
                employee.Email == "" ||
                employee.Gender == "" ||
                employee.Name == "" ||
                employee.PhoneNumber == 0 ||
                employee.PhoneNumber == null ||
                employee.PositionId == null ||
                employee.Wage == 0 ||
                employee.Wage == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
