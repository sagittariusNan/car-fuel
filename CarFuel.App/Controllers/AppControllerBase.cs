using CarFuel.Services;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace CarFuel.App.Controllers
{
    public abstract class AppControllerBase : Controller
    {
        private readonly IMemberService m;

        public AppControllerBase(IMemberService m)
        {
            this.m = m;
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            if (User.Identity.IsAuthenticated)
            {
                m.SetCurrentMember(User.Identity.GetUserId());
            }
        }
    }
}