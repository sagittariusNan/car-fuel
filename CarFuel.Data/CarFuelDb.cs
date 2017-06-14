using CarFuel.Models;
using System.Data.Entity;

namespace CarFuel.Data
{
    public class CarFuelDb : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Plan> Plans { get; set; }
    }
}
