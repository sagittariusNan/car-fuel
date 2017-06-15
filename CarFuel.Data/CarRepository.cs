using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFuel.Data
{
    public class CarRepository
    {

        private CarFuelDb db = new CarFuelDb();

        public IQueryable<Car> Query(Func<Car, bool> condition)
        {
            return db.Cars.Where(condition).AsQueryable();
        }

        public void Add(Car item)
        {
            db.Cars.Add(item);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Car Find(Guid id)
        {
            return Query(c => c.Id == id).SingleOrDefault();

        }
    }
}