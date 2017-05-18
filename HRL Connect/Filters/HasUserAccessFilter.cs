using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HRL_Connect.Filters
{
    public class HasUserAccessFilter : ActionFilterAttribute
    {
        private  Lazy<List<string>> userRoleList = new Lazy<List<string>>(() => new List<string>());

        public  List<string> UserRoleList { get { return userRoleList.Value; } }
        public HasUserAccessFilter(params object[] careerLevels)
        {
            UserRoleList.Add(Role.SuperAdmin); //adding superAdmin as he/she has access to all.
            foreach (var careerLevel in careerLevels)
            {
                UserRoleList.Add(careerLevel.ToString());
            }

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string loggedInUserRole = filterContext.RouteData.Values["LoggedInUserRole"] as string;

            if (!UserRoleList.Any(role => role == loggedInUserRole))
            {
                filterContext.HttpContext.Session.Remove("Person");
                throw new Exception("Access is denied!");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}