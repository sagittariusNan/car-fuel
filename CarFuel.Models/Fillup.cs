using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Models {
    public class FillUp {
        public int Id { get; set; }
        public int Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }
 
        public double? KilometersPerLiter {
            get {
                if (NexFillUp == null) {
                    return null;
                }
                else {
                    return (this.NexFillUp.Odometer - this.Odometer) / NexFillUp.Liters;
                } 
            }
        }

        public virtual Car Car { get; set; }

        public FillUp NexFillUp { get; set; }
    }
}
