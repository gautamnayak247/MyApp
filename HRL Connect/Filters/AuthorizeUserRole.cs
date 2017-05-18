using System.Web.Mvc;

namespace HRL_Connect.Filters
{
    public class AuthorizeUserRoleFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var id = filterContext.RouteData.Values["id"];
        }
    }
}