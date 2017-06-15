using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using CarFuel.Models; 
using Xunit;

namespace CarFuel.Models.Facts
{
    public class CarFact
    { 
        public class AvgFillUp
        {
            [Fact]
            public void Avg_ReturnsNull()
            {
                //arrrang
                Car c = new Car();
                FillUp f1 = new FillUp();
                f1.Odometer = 1000;
                c.FillUps.Add(f1);

                //act
                double? result = c.AverageKilometersPerLiter;

                //assert
                Assert.Null(result);
            }

            [Fact]
            public void SecondFillUp_Return10()
            {
                //arrrang
                Car c = new Car();
                FillUp f1 = new FillUp();
                f1.Odometer = 1000;
                f1.Liters = 60;

                FillUp f2 = new FillUp();
                f2.Odometer = 1500;
                f2.Liters = 50;

                f1.NexFillUp = f2;

                c.FillUps.Add(f1);
                c.FillUps.Add(f2);
                //act
                double? result = c.AverageKilometersPerLiter;

                //assert
                Assert.Equal(10, result);
            }

            [Fact]
            public void ThirdFillUp_Return12()
            {
                //arrrang
                Car c = new Car();
                FillUp f1 = new FillUp();
                f1.Odometer = 1000;
                f1.Liters = 60;

                FillUp f2 = new FillUp();
                f2.Odometer = 1500;
                f2.Liters = 50;
                f1.NexFillUp = f2;

                FillUp f3 = new FillUp();
                f3.Odometer = 2100;
                f3.Liters = 50;
                f2.NexFillUp = f3;

                c.FillUps.Add(f1);
                c.FillUps.Add(f2);
                c.FillUps.Add(f3);

                //act
                double? result = c.AverageKilometersPerLiter;

                //assert
                Assert.Equal(11.09, result);
            } 
        }
    }
}
