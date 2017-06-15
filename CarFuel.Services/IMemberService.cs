using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public interface IMemberService : IService<Member>
    {
        Member CurrentMember { get; }
        bool SetCurrentMember(string memberId);
        void CreateMember(string userId, string name, string email);
    }
}
