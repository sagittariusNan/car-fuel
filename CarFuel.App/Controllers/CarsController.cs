using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc.Filters;
using CarFuel.App.Filters;

namespace CarFuel.App.Controllers
{
    [Authorize]
    public class CarsController : AppControllerBase
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService, IMemberService m) : base(m)
        {
            this.carService = carService; 
        }

        public ActionResult Index()
        {
            IEnumerable<Car> cars = carService.All();

            return View(cars);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Car item)
        {

            ModelState.Remove("DateAdded");

            if (ModelState.IsValid)
            {

                //item.OwnerId = User.Identity.GetUserId();
                item.DateAdded = DateTime.Now;

                carService.Add(item);
                carService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult AddFillUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFillUp(Guid Id, FillUp item)
        {
            if (ModelState.IsValid)
            {
                carService.AddFillUp(Id, item);
                carService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(item);
        }

    }
}