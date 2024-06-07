using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.Models;
using System.Collections.Generic;
using System;

namespace JobInMinuteServer.Models
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }

        [ForeignKey("EmployerID")]
        public int EmployerId { get; set; }


        [ForeignKey("CityCode")]
        public int CityCode { get; set; }

        [Required]
        public string Title { get; set; }

       [Required]
        public string Description { get; set; }

       [Required]
        public string SkillsRequired { get; set; }

       [Required]
        public string Address { get; set; }

       [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        public float Salary { get; set; }
    }
}
