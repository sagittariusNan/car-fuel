using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Models
{
    public class Car
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Plate No.")]
        [StringLength(20)]
        public string PlateNo { get; set; }

        [Required]
        [StringLength(30)]
        public string Make { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Range(0, 9999)]
        public int Year { get; set; }

        [Display(Name = "Engine Size (cc.)")]
        [Range(0, 9999)]
        public int? EngineSizeCC { get; set; }

        public FillUp AddFillUp(int odometer, double liters, bool isFull = true)
        {
            var f = new FillUp();
            f.Odometer = odometer;
            f.Liters = liters;
            f.IsFull = isFull;
            f.NextFillUp = null;

            if (FillUps.Count > 0)
            {
                FillUps.Last().NextFillUp = f;
            }

            FillUps.Add(f);
            return f;
        }

        public DateTime DateAdded { get; set; }

        [StringLength(36)]
        public string OwnerId { get; set; }

        public virtual ICollection<FillUp> FillUps { get; set; }

        public Car()
        {
            FillUps = new HashSet<FillUp>();
        }

        public double? AverageKilometersPerLiter
        {
            get
            {
                double? area = 0.0;
                int odmeter = 0;
                int totalOdmeter = 0;

                if (FillUps.Count() <= 1)
                {
                    return null;
                }
                else
                {
                    foreach (var f in FillUps.OrderBy(x=>x.Id))
                    {
                        if (f.NexFillUp != null)
                        {
                            odmeter = f.NexFillUp.Odometer - f.Odometer;
                            totalOdmeter += odmeter;
                            area += odmeter * f.KilometersPerLiter;
                        }
                    }
                    return Math.Round(area.Value/totalOdmeter,2);
                }
            }
        }
    }
}
