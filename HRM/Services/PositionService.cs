using HRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class PositionService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public PositionService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<Position> GetAllPositions()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Positions.ToList();
        }

        public Position GetPosition(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Positions.Where(x => x.PositionId == id).FirstOrDefault();
        }

        public void AddPosition(Position position)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Add(position);
            context.SaveChanges();
        }

        public bool Delete(Position position)
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context.Employees.Where(x => x.PositionId == position.PositionId).Count() == 0)
            {
                context.Positions.Remove(position);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(Position position)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Positions.Update(position);
            context.SaveChanges();
        }
    }
}
