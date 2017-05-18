using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRL_Connect.Models
{
    public class ReportActiveUnmappedPeopleViewModel
    {
        public int UserId { get; set; }
        public string EnterpriseId { get; set; }
        public string CareerLevel { get; set; }
        public string Supervisor { get; set; }
        public string Project { get; set; }
        public string Du { get; set; }
    }
}