using HRL_Connect.Models;
using HRLConnect.BL;
using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HRL_Connect.Controllers
{
    public class ReferenceDataController : BaseController
    {
        static IRepository repos;
        private Lazy<ReferenceDataBL> bLogicObj = new Lazy<ReferenceDataBL>(() => new ReferenceDataBL(ReferenceDataController.repos));
        public ReferenceDataBL BLogicObj { get { return bLogicObj.Value; } }
        public ReferenceDataController(IRepository repo) : base(repo)
        {
            repos = repo;
        }
        // GET: ReferenceData
        public ActionResult Index()
        {
            ViewBag.ViewName = "EditPeople";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string operation)
        {
            //switch (operation)
            //{
            //    case "add":
            //        ViewBag.ViewName = "AddPeople";
            //        return PartialView("AddPeople");
            //    case "edit":
            //        ViewBag.ViewName = "EditPeople";
            //        break;
            //    default:
            //        ViewBag.ViewName = "DeletePeople";
            //        break;
            //}
            return View();
        }
        [HttpGet]
        public ActionResult AddPeople()
        {
            return PartialView();
        }

        [HttpPost]
        public bool AddPeoples(AddPeopleViewModel people)
        {
            if (ModelState.IsValid)
            {
                People newPeople = new People();
                newPeople.EnterpriseId = people.EnterpriseId;
                newPeople.Name = people.Name;
                newPeople.Mobile = people.Mobile;
                newPeople.Email = people.Email;
                newPeople.CLFK = people.CLFK;
                newPeople.EmploymentTypeFK = people.EmploymentTypeFK;
                newPeople.DuId = people.DuId;
                newPeople.ProjectID = people.ProjectId;
                newPeople.IsActive = people.IsActive;
                newPeople.SupervisorFK = people.SupervisorFK;
                newPeople.AccentureDOJ = people.AccentureDOJ;
                newPeople.ProjectDOJ = people.ProjectDOJ;
                newPeople.AccentureDOJ = people.AccentureDOJ;
                newPeople.ProjectDOJ = people.ProjectDOJ;
                return BLogicObj.AddPeople(newPeople);
            }
            return false;
        }

        [HttpGet]
        public ActionResult DeletePeople()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DeletePeople(People p)
        {
            BLogicObj.AddPeople(new People());
            return View();
        }
        public JsonResult GetAllPeople()
        {
            List<People> peopleList = BLogicObj.GetAllPeople();
            return Json(peopleList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCareerLevel()
        {
            var careerLevel = BLogicObj.GetCareerLevel();
            return Json(careerLevel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmploymentType()
        {
            var employmentType = BLogicObj.GetEmploymentType();
            return Json(employmentType, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDu()
        {
            var duList = BLogicObj.GetDu();
            return Json(duList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProject(int duId)
        {
            var projectList = BLogicObj.GetProject(duId);
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSupervisor(int duId)
        {
            var supervisorList = BLogicObj.GetSupervsior(duId);
            return Json(supervisorList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDu()
        {
            return PartialView();
        }
        public bool AddDu(Du du)
        {
            if (ModelState.IsValid)
            {
                return BLogicObj.AddDu(du);
            }
            
            return false;
        }
    }
}