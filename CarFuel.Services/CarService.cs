using CarFuel.Data;
using CarFuel.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using CarFuel.Utilities;

namespace CarFuel.Services
{
    public class CarService : ServiceBase<Car>, ICarService
    {
        private readonly IMemberService memberService;

        public CarService(IRepository<Car> baseRepo,
            IMemberService memberService) : base(baseRepo)
        {
            this.memberService = memberService;
        }

        public override Car Add(Car item)
        {
            item.OwnerId = memberService.CurrentMember.Id;
            item.DateAdded = SystemTime.Now();
            return base.Add(item);
        }

        public override Car Find(params object[] keys)
        {
            Guid id = (Guid)keys[0];
            return Query(c => c.Id == id).SingleOrDefault();
        }

        // Member can get only his or her cars.
        public override IQueryable<Car> Query(Func<Car, bool> criteria)
        {
            return base.Query(criteria)
                       .Where(c => c.OwnerId == memberService.CurrentMember.Id);
        } 

        public FillUp AddFillUp(Guid Id, FillUp item)
        {
            Car c = Find(Id);
            FillUp f = c.AddFillUp(item.Odometer, item.Liters, item.IsFull);
            SaveChanges();

            return f;
        }

    }
}