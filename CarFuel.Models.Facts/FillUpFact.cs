using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarFuel.Models;

namespace CarFuel.Models.Facts {
    public class FillUpFact {

        [Fact]
        public void KML_ReturnsNull() {
            //arrrang
            FillUp f1 = new FillUp();
            f1.Odometer = 1000;
            //act
            double? result = f1.KilometersPerLiter;
            //assert
            Assert.Null(result);

        }

        [Fact]
        public void SecondFillUp_Return10() {
            //arrrang
            FillUp f1 = new FillUp();
            f1.Odometer = 1000;
            f1.Liters = 60;
            FillUp f2 = new FillUp();
            f2.Odometer = 1500;
            f2.Liters = 50;
            f1.NexFillUp = f2;

            //act
            double? result = f1.KilometersPerLiter;

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void ThirdFillUp_Return12() {
            //arrrang
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

            //act
            double? result = f2.KilometersPerLiter;

            //assert
            Assert.Equal(12, result);
        }
    }
}
