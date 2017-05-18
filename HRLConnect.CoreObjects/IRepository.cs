using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public interface IRepository
    {
        string MyData();
        Person GetPersonDetails(string enterpriseId);
        List<CareerLevel> GetCareerLevelId();
        List<Du> GetDuNames();
        List<string> GetEnterpriseIds();

        //reports 
        #region Reports
        List<People> GetActiveUnmappedPeople(int duId);
        List<ConnectsIDone> GetConnectsIDone(string enterpriseId);
        List<People> GetInActivePeople(int duId);
        List<IndividualConnects> GetIndividualConnectsMySpan(string enterpriseId);
        List<LeadsConnects> GetLeadsConnectsMySpan(string enterpriseId);
        List<ConnectsIDone> GetMyConnects(string enterpriseId);
        #endregion

        #region ReferenceData
        //Manage Reference Data
        bool AddPeople(People p);
        List<CareerLevel> GetCareerLevel();
        List<EmploymentType> GetEmploymentType();
        List<Du> GetDu();
        List<Project> GetProject(int duId);
        List<People> GetSupervisor(int duId);

        //Manage Du
        bool AddDu(Du du);
        //List<People> GetAllPeople();
        #endregion

    }
}
