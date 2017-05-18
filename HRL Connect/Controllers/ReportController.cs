using HRL_Connect.Models;
using HRLConnect.BL;
using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRL_Connect.Controllers
{
    public class ReportController : BaseController
    {
        static IRepository repos;
        private Lazy<ReportBL> bLogicObj = new Lazy<ReportBL>(() => new ReportBL(ReportController.repos));
        public ReportBL BLogicObj { get { return bLogicObj.Value; } }
        // GET: Report
        public ReportController(IRepository repo) : base(repo)
        {
            repos = repo;
        }
        public ActionResult Index()
        {
            //var t = BLogicObj.GetPersonDetailss("abhishek.patni");
            return View();
        }

        [HttpGet]
        public ActionResult GetActiveUnmappedPeople(int duId)
        {
            List<ReportActiveUnmappedPeopleViewModel> unmappedPeopleModel = new List<ReportActiveUnmappedPeopleViewModel>();

            List<People> unmappedPeopleList = BLogicObj.GetActiveUnmappedPeople(duId);

            foreach (var people in unmappedPeopleList)
            {
                ReportActiveUnmappedPeopleViewModel activeUnmappedPeople = new ReportActiveUnmappedPeopleViewModel();
                activeUnmappedPeople.UserId = people.UserId;
                activeUnmappedPeople.Supervisor = people.Supervisor;
                activeUnmappedPeople.Du = people.Du;
                activeUnmappedPeople.CareerLevel = people.CareerLevel;
                activeUnmappedPeople.EnterpriseId = people.EnterpriseId;
                activeUnmappedPeople.Project = people.Project;
                unmappedPeopleModel.Add(activeUnmappedPeople);
            }

            return Json(unmappedPeopleModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetConnectsIDone(string enterpriseId)
        {
            var connects = BLogicObj.GetConnectIDone(enterpriseId);
            return Json(connects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInActivePeople(int duId)
        {
            var peopleList = BLogicObj.GetInActivePeople(duId);
            return Json(peopleList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIndividualConnectsMySpan(string enterpriseId)
        {
            var individualConnectsMySpan = BLogicObj.GetIndividualConnectsMySpan(enterpriseId);
            return Json(individualConnectsMySpan, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLeadsConnectsMySpan(string enterpriseId)
        {
            var leadsConnectsMySpan = BLogicObj.GetLeadsConnectsMySpan(enterpriseId);
            return Json(leadsConnectsMySpan, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyConnects(string enterpriseId)
        {
            var myConnects = BLogicObj.GetMyConnects(enterpriseId);
            return Json(myConnects, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDuNames()
        {
            var duNames = BLogicObj.GetDuNames();
            return Json(duNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnterpriseIds()
        {
            var result = BLogicObj.GetEnterpriseIds();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}