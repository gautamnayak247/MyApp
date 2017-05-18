using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRLConnect.BL;
namespace HRL_Connect.Controllers
{
    public class SuperBaseController : Controller
    {
        private PersonBL bLogicObj;
        public static Person PersonDetails { get; set; }
        public SuperBaseController(IRepository repo)
        {
            bLogicObj = new PersonBL(repo);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string enterpriseId = "abhishek.patni";
            PersonDetails = GetPersonDetails(enterpriseId);
            filterContext.RouteData.Values.Add("LoggedInUserRole", PersonDetails.UserRole);
        }

        [NonAction]
        private Person GetPersonDetails(string enterpriseId)
        {
            Person _person;
            if (null == Session["Person"])
            {
                _person = bLogicObj.GetPersonDetails(enterpriseId);
                Session["Person"] = _person;
                return _person;
            }
            else
            {
                _person = Session["Person"] as Person;
                return _person;
            }
        }
    }
}