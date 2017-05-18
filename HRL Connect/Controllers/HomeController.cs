using HRL_Connect.Filters;
using HRL_Connect.Models;
using HRLConnect.BL;
using HRLConnect.CoreObjects;
using HRLConnect.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRL_Connect.Controllers
{
    public class HomeController : BaseController
    {
        private MyBl bLogicObj;
        public HomeController(IRepository repo) : base(repo)
        {
            bLogicObj = new MyBl(repo);
            LayoutViewModel layoutModel = new LayoutViewModel();
            layoutModel.PersonDetails = PersonDetails;
            ViewBag.LayoutModel = layoutModel;
        }

        [HasUserAccessFilter(CareerLevelEnum.AmAndTL, CareerLevelEnum.SeniorMgrAndMgr, CareerLevelEnum.Others)]
        public ActionResult Index()
        {
            ViewBag.LoggedInUser = "Welcome " + PersonDetails.EnterpriseId;
            return View();
        }

        [HasUserAccessFilter(CareerLevelEnum.AmAndTL, CareerLevelEnum.SeniorMgrAndMgr, CareerLevelEnum.Others)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HasUserAccessFilter(CareerLevelEnum.AmAndTL, CareerLevelEnum.SeniorMgrAndMgr, CareerLevelEnum.Others)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}