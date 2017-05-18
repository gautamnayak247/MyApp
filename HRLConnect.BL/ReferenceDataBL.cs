using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.BL
{
    public class ReferenceDataBL
    {
        IRepository repository;
        public ReferenceDataBL(IRepository repo)
        {
            repository = repo;
        }
        public bool AddPeople(People p)
        {
            p.CreatedBy = "gautam.nayak";
            return repository.AddPeople(p);
        }

        public List<People> GetAllPeople()
        {
            return null;
            //return repository.GetAllPeople();
        }

        public List<CareerLevel> GetCareerLevel()
        {
            return repository.GetCareerLevel().OrderBy(n => n.CLID).ToList();
        }

        public List<EmploymentType> GetEmploymentType()
        {
            return repository.GetEmploymentType().OrderBy(n => n.Id).ToList();
        }
        public List<Du> GetDu()
        {
            return repository.GetDu().OrderBy(n => n.DuName).ToList();
        }

        public List<Project> GetProject(int duId)
        {
            return repository.GetProject(duId);
        }

        public List<People> GetSupervsior(int duId)
        {
            return repository.GetSupervisor(duId);
        }

        public bool AddDu(Du du)
        {
            return repository.AddDu(du);
        }
    }
}
