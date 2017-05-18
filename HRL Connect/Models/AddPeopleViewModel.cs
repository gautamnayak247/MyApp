using System;
using System.ComponentModel.DataAnnotations;

namespace HRL_Connect.Models
{
    public class AddPeopleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EnterpriseId { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int CLFK { get; set; }
        [Required]
        public int EmploymentTypeFK { get; set; }
        [Required]
        public int DuId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int SupervisorFK { get; set; }
        [Required]
        public DateTime AccentureDOJ { get; set; }
        [Required]
        public DateTime ProjectDOJ { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}