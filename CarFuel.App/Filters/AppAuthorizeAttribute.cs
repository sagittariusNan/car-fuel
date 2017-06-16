using CarFuel.Services;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace CarFuel.App.Filters
{
    public class AppAuthorizeAttribute : AuthorizeAttribute
    {
        public IMemberService MemberService { get; set; }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                MemberService.SetCurrentMember(filterContext.HttpContext.User.Identity.GetUserId());
            }
        }
    }
}