using CarFuel.Data;
using CarFuel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarFuel.Services.Facts
{
    public class MemberServiceFact
    {

        public class CreateMember
        {

            [Fact]
            public void BasicUsage()
            {
                var repo = new Mock<IRepository<Member>>();
                var m = new MemberService(repo.Object);

                m.CreateMember("M1", "Member1", "Email1");

                // has m called the Add method of the repo or not?
                repo.Verify(x => x.Add(It.IsAny<Member>()), Times.Once);
            }

            [Fact]
            public void MembersHasStoredCorrectly()
            {
                var repo = new Mock<IRepository<Member>>();
                var m = new MemberService(repo.Object);
                var cols = new List<Member>();

                repo.Setup(x => x.Add(It.IsAny<Member>()))
                    .Callback<Member>(member =>
                    {
                        cols.Add(member);
                    });
                repo.Setup(x => x.Query(It.IsAny<Func<Member, bool>>()))
                    .Returns(cols.AsQueryable());


                m.CreateMember("M1", "Member1", "Email1");
                m.CreateMember("M2", "Member2", "Email2");

                var members = m.All();

                Assert.Equal(2, members.Count());
            }
        }
    }
}
