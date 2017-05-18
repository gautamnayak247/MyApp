using System.Collections.Generic;
using System.Linq;
using HRLConnect.CoreObjects;
using System.Configuration;

namespace HRLConnect.BL
{
    public class PersonBL
    {
        public IRepository repo;
        public PersonBL(IRepository repo)
        {
            this.repo = repo;
        }
        public Person GetPersonDetails(string enterpriseId)
        {
            var person = repo.GetPersonDetails(enterpriseId);
            person.UserRole = GetUserRole(person.CareerLevel, person.EnterpriseId);
            return person;
        }
        public string GetUserRole(string careerLevel, string enterpriseId)
        {
            string role = "";
            List<CareerLevel> careerLevelIdList = repo.GetCareerLevelId();
            int careerLevelId = careerLevelIdList.Single(level => level.CareerLev == careerLevel).CLID;

            if (careerLevelId < 5)
            {
                role= Role.Others;
            }
            else if (careerLevelId >= 5 && careerLevelId < 8)
            {
                role= Role.AmAndTL;
            }
            else
            {
                role= Role.SeniorMgrAndMgr;
            }
            var superAdmins = ConfigurationManager.AppSettings["SuperAdmin"].ToString();
            var superAdminList = superAdmins.Split(';').ToList().Select(x=>x.ToLower()).ToList();

            if (superAdminList.Contains(enterpriseId.ToLower()))
            {
                role = Role.SuperAdmin;
            }
            return role;
        }
    }
}
