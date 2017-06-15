using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public class MemberService : ServiceBase<Member>, IMemberService
    {
        public MemberService(IRepository<Member> baseRepo) : base(baseRepo)
        {
        }

        public Member CurrentMember { get; private set; }

        public bool SetCurrentMember(string userId)
        {
            var member = Find(userId);

            if (member != null)
            {
                CurrentMember = member;
                return true;
            }
            else
            {
                CurrentMember = null;
                return false;
            }
        }

        public void CreateMember(string userId, string name, string email)
        {
            Add(new Member() { Id = userId, Name = name, Email = email, PlanCode = "FREE" });
            SaveChanges();
        }

        public override Member Find(params object[] keys)
        {
            string id = (string)keys[0];
            return Query(c => c.Id == id).SingleOrDefault();
        }

    }
}
