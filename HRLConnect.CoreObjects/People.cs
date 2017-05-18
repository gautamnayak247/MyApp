using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public class People
    {
        public int UserId { get; set; }
        public string EnterpriseId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int CLFK { get; set; }
        public string CareerLevel { get; set; }
        public int EmploymentTypeFK { get; set; }
        public int ProjectID { get; set; }
        public string Project { get; set; }
        public bool IsActive { get; set; }
        public int SupervisorFK { get; set; }
        public string Supervisor { get; set; }
        public int DuId { get; set; }
        public string Du { get; set; }
        public DateTime AccentureDOJ { get; set; }
        public DateTime ProjectDOJ { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
