using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CarFuel.Data
{
    public class MemberRepository : RepositoryBase<Member>
    {
        public MemberRepository(DbContext context) : base(context)
        {
        }
    }
}
