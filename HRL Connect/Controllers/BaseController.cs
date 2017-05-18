using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRL_Connect.Controllers
{
    public class BaseController : SuperBaseController
    {
        public BaseController(IRepository repo):base(repo)
        {
            
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        
    }
}