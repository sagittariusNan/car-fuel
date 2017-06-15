using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public class PlanService
    {
        private PlanRepository planRepo = new PlanRepository();

        public IEnumerable<Plan> GetAll()
        {
            return planRepo.Query(p => true);
        }

        public IEnumerable<Plan> Get(Func<Plan, bool> condition)
        {
            return planRepo.Query(condition);
        }

        public void Add(Plan item)
        {
            planRepo.Add(item);
        }

        public void SaveChanges()
        {
            planRepo.SaveChanges();
        }
    }
}
