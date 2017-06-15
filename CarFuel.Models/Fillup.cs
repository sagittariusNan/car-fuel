using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Models
{
    public class FillUp
    {
        public int Id { get; set; }
        public int Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }

        public double? KilometersPerLiter
        {
            get
            {
                return 0;
            }
        }
        public FillUp NextFillUp { get; set; }
        public virtual Car Car { get; set; }
    }
}
