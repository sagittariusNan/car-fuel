using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CarFuel.Services
{
    public class CarService
    {

        private CarRepository carRepo = new CarRepository();

        public IEnumerable<Car> GetAll()
        {
            return carRepo.Query(c => true);
        }

        public IEnumerable<Car> Get(Func<Car, bool> condition)
        {
            return carRepo.Query(condition);
        }

        public Car Find(params object[] keys)
        {
            Guid id = (Guid)keys[0];
            return carRepo.Query(c => c.Id == id).SingleOrDefault();
        }

        public void Add(Car item)
        {
            carRepo.Add(item);
        }

        public void AddFillUp(Guid Id, FillUp item)
        {
            Car c = carRepo.Find(Id);
            c.AddFillUp(item.Odometer, item.Liters,item.IsFull);
            carRepo.SaveChanges();
        }

        public void SaveChanges()
        {
            carRepo.SaveChanges();
        }
    }
}