using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public class PlanService : ServiceBase<Plan>, IPlanService
    {
        public PlanService(IRepository<Plan> baseRepo) : base(baseRepo)
        {
        }

        public override Plan Find(params object[] keys)
        {
            string id = (string)keys[0];
            return Query(c => c.Code == id).SingleOrDefault();
        }


    }
}
