using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CarFuel.Data;
using CarFuel.Models;
using CarFuel.Services;
using System.Data.Entity;
using CarFuel.App.Filters;

namespace CarFuel.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitialAutoFac();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitialAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CarRepository>().As<IRepository<Car>>().InstancePerRequest();
            builder.RegisterType<MemberRepository>().As<IRepository<Member>>().InstancePerRequest();
            builder.RegisterType<PlanRepository>().As<IRepository<Plan>>().InstancePerRequest();

            builder.RegisterType<CarService>().As<IService<Car>>().As<ICarService>().InstancePerRequest();
            builder.RegisterType<MemberService>().As<IService<Member>>().As<IMemberService>().InstancePerRequest();
            builder.RegisterType<PlanService>().As<IService<Plan>>().As<IPlanService>().InstancePerRequest();

            builder.RegisterType<CarFuelDb>().As<DbContext>().InstancePerRequest();

            builder.RegisterType<AppAuthorizeAttribute>().PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
