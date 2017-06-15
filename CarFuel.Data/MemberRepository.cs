using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Data
{
    public class MemberRepository
    {
        private CarFuelDb db = new CarFuelDb();

        public IQueryable<Member> Query(Func<Member, bool> condition)
        {
            return db.Members.Where(condition).AsQueryable();
        }

        public void Add(Member item)
        {
            db.Members.Add(item);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
