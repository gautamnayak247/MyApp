using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public class LeadsConnects
    {
        public string SupervisorEID { get; set; }
        public int? Q1DirectReportee { get; set; }
        public int? Q1NoOfConnectsDone { get; set; }
        public int? Q2DirectReportee { get; set; }
        public int? Q2NoOfConnectsDone { get; set; }
        public int? Q3DirectReportee { get; set; }
        public int? Q3NoOfConnectsDone { get; set; }
        public int? Q4DirectReportee { get; set; }
        public int? Q4NoOfConnectsDone { get; set; }
    }
}
