﻿using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class DepartmentService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public DepartmentService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<Department> GetAllDepartments()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
        }

        public void AddDepartment(Department department)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Add(department);
            context.SaveChanges();
        }

        public void Delete(Department department)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Departments.Remove(department);
            context.SaveChanges();
        }

        public void Update(Department department)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Departments.Update(department);
            context.SaveChanges();
        }
    }
}
