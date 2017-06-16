using CarFuel.Models;
using System.Data.Entity;

namespace CarFuel.Data
{
    public class PlanRepository : RepositoryBase<Plan>
    {
        public PlanRepository(DbContext context) : base(context)
        {
        }
    }
}
