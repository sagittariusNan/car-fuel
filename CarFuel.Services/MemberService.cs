using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public class MemberService
    {
        private MemberRepository memberRepo = new MemberRepository();

        public Member CurrentUser { get; private set; }

        public bool SetCurrentUser(string UserId)
        {
            var member = Find(UserId);

            if (member != null)
            {
                CurrentUser = member;
                return true;
            }
            else
            {
                CurrentUser = null;
                return false;
            }
        }

        public void CreateMember(string Id, string Name, string Email)
        {
            memberRepo.Add(new Member() { Id = Id, Name = Name, Email = Email, PlanCode = "FREE" });
            memberRepo.SaveChanges();
        }

        public IEnumerable<Member> GetAll()
        {
            return memberRepo.Query(m => true);
        }

        public IEnumerable<Member> Get(Func<Member, bool> condition)
        {
            return memberRepo.Query(condition);
        }

        public Member Find(params object[] keys)
        {
            string id = (string)keys[0];
            return memberRepo.Query(c => c.Id == id).SingleOrDefault();
        }

        public void Add(Member item)
        {
            memberRepo.Add(item);
        }


        public void SaveChanges()
        {
            memberRepo.SaveChanges();
        }
    }
}
