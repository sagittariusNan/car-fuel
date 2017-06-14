using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Data
{
    public class PlanRepository
    {
        private CarFuelDb db = new CarFuelDb();

        public IQueryable<Plan> Query(Func<Plan, bool> condition)
        {
            return db.Plans.Where(condition).AsQueryable();
        }

        public void Add(Plan item)
        {
            db.Plans.Add(item);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
