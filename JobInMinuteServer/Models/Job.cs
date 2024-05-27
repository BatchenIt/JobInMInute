using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobInMinuteServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace JobInMinuteServer.Models
    {
        using System;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;

        namespace JobInMinuteServer.Models
        {
            public class Job
            {
                [Key]
                public int JobID { get; set; }

                [ForeignKey("EmployerID")]
                public int EmployerId { get; set; }
                public Employer? Employer { get; set; }

                [ForeignKey("CityCode")]
                public int CityCode { get; set; }
                public City? City { get; set; }

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

    }

}
