using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Services
{
    public interface ICarService : IService<Car>
    {
        FillUp AddFillUp(Guid carId, FillUp fillup);
    }
}
