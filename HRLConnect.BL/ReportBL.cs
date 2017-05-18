using HRLConnect.CoreObjects;
using System.Collections.Generic;
using System.Linq;

namespace HRLConnect.BL
{
    public class ReportBL
    {
        private IRepository repo;
        public ReportBL()
        {

        }
        public ReportBL(IRepository repository)
        {
            repo = repository;
        }
        public List<People> GetActiveUnmappedPeople(int duId)
        {
            return repo.GetActiveUnmappedPeople(duId).OrderBy(n => n.CareerLevel).ToList();

        }

        public List<ConnectsIDone> GetConnectIDone(string enterpriseId)
        {
            return repo.GetConnectsIDone(enterpriseId).OrderBy(n => n.DateOfConnect).ToList();
        }

        public List<Du> GetDuNames()
        {
            return repo.GetDuNames();
        }

        public List<string> GetEnterpriseIds()
        {
            return repo.GetEnterpriseIds();
        }

        public List<People> GetInActivePeople(int duId)
        {
            return repo.GetInActivePeople(duId);
        }

        public List<IndividualConnects> GetIndividualConnectsMySpan(string enterpriseId)
        {
            return repo.GetIndividualConnectsMySpan(enterpriseId);
        }

        public List<LeadsConnects> GetLeadsConnectsMySpan(string enterpriseId)
        {
            return repo.GetLeadsConnectsMySpan(enterpriseId);
        }

        public List<ConnectsIDone> GetMyConnects(string enterpriseId)
        {
            return repo.GetMyConnects(enterpriseId);
        }
    }
}
