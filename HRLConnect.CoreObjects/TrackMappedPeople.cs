using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    class TrackMappedPeople
    {
        public int TrackId { get; set; }
        public string EnterpriseId { get; set; }
        public string SupervisorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
