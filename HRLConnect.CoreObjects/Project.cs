using System;

namespace HRLConnect.CoreObjects
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int DuId { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
