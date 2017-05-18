using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    class Connects
    {
        public int ConnectId { get; set; }
        public int SupervisorFK { get; set; }
        public string TeamMemberEId { get; set; }
        public int TeamMemberUserId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ConnectDate { get; set; }
        public int StatusId { get; set; }
        public string PrimarySkill { get; set; }
        public string WorkStream { get; set; }
        public string Contribution { get; set; }
        public string AreasOfImprovement { get; set; }
        public string WhatIsWell { get; set; }
        public string WhatToImprove { get; set; }
        public string Aspiration { get; set; }
        public string AcceptanceComment { get; set; }
        public string RequestChange { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
