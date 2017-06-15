using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Models.Facts
{
    public class CarFact
    {
        public class AddFillUp
        {
            [Fact]
            public void FirstAddFillUp()
            {
                //a
                Car c = new Car(); 
                
                //a
                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 60.0);

                //a
                Assert.Null(f1.NextFillUp);
                Assert.Equal(1, c.FillUps.Count);
            }

            [Fact]
            public void TwoAddFillUp()
            {
                //a
                Car c = new Car();

                //a
                var f1 = c.AddFillUp(1000, 60.0);
                var f2 = c.AddFillUp(1500, 50.0); 

                //a
                Assert.Same(f2, f1.NextFillUp);/*ต้องเป็น obj เดียวกัน*/
                Assert.Equal(2, c.FillUps.Count);
            }

            [Fact]
            public void ThreeAddFillUp()
            {
                //a
                Car c = new Car();

                //a
                var f1 = c.AddFillUp(1000, 60.0);
                var f2 = c.AddFillUp(1500, 50.0);
                var f3 = c.AddFillUp(2100, 50.0);

                //a
                Assert.Same(f3, f2.NextFillUp);/*ต้องเป็น obj เดียวกัน*/
                Assert.Equal(3, c.FillUps.Count);
            }

            //[Fact]
            //public void FourAddFillUp()
            //{
            //    //a
            //    Car c = new Car();
            //    FillUp f1 = new FillUp();
            //    f1.Odometer = 1000;
            //    f1.Liters = 60;
            //    f1.IsFull = true;
            //    FillUp f2 = new FillUp();
            //    f2.Odometer = 1500;
            //    f2.Liters = 50;
            //    f2.IsFull = true;
            //    FillUp f3 = new FillUp();
            //    f3.Odometer = 2100;
            //    f3.Liters = 50;
            //    f3.IsFull = true;
            //    /*เติมครั้งที่ 4 ไม่เต็มถัง*/
            //    FillUp f4 = new FillUp();
            //    f4.Odometer = 2500;
            //    f4.Liters = 20;
            //    f4.IsFull = false;
            //    //a
            //    c.AddFillUp(f1);
            //    f1.NextFillUp = c.AddFillUp(f2);
            //    f2.NextFillUp = c.AddFillUp(f3);
            //    f3.NextFillUp = c.AddFillUp(f4);
            //    //a
            //    Assert.Same(f4, f3.NextFillUp);/*ต้องเป็น obj เดียวกัน*/
            //    Assert.Equal(4, c.FillUps.Count);
            //}
        }
    }
}
