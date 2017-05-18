using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public class ConnectsIDone
    {
        public int ConnectId { get; set; }
        public string MonthOfConnect { get; set; }
        public string EnterpriseId { get; set; }
        public string ProjectName { get; set; }
        public string Supervisor { get; set; }
        public DateTime DateOfConnect { get; set; }
        public string ConnectStatus { get; set; }
        public int StatusId { get; set; }
        public string UiLink { get; set; }
    }
}
