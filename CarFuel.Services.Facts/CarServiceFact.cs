using CarFuel.Models;
using CarFuel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Services.Facts
{
    public class CarServiceFact
    {

        public class AddCar
        {
            private IMemberService m;
            private ICarService c;

            public AddCar()
            {
                m = new MemberService(new FakeRepository<Member>());
                c = new CarService(new FakeRepository<Car>(), m);

                m.CreateMember("M1", "Member 1", "m1@company.com");
                m.CreateMember("M2", "Member 2", "m2@company.com");
            }

            [Fact]
            public void NewCar_HasCorrectOwner()
            {  
                var c1 = new Car();
                m.SetCurrentMember("M1");

                c.Add(c1);

                Assert.Equal("M1", c1.OwnerId);
            }


            [Fact]
            public void NewCar_HasDateAddedAsNow()
            { 
                var dt = DateTime.Now; 
                var c1 = new Car();
                m.SetCurrentMember("M1");
                SystemTime.SetDateTime(dt); 

                c.Add(c1);

                Assert.Equal(dt, c1.DateAdded);
            }
        }

        public class GetCars
        {

            [Fact]
            public void MemberCanGetOnlyTheirOwnCars()
            {
                var m = new MemberService(new FakeRepository<Member>());
                var c = new CarService(new FakeRepository<Car>(), m);

                m.CreateMember("M1", "Member 1", "");
                m.CreateMember("M2", "Member 2", "");

                m.SetCurrentMember("M1");

                var c1 = new Car();
                c.Add(c1);
                Assert.Equal("M1", c1.OwnerId);

                m.SetCurrentMember("M2");
                var c2 = new Car();
                c.Add(c2);
                Assert.Equal("M2", c2.OwnerId);

                m.SetCurrentMember("M1");
                var cars = c.All().ToList();

                Assert.Equal(1, cars.Count());
                Assert.Same(c1, cars.First());
            }

        }
    }
}
