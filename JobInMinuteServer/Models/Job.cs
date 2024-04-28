using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class Job
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public DateTime StartAt{ get; set; }
        public DateTime EndAt { get; set; }
        public float Salary { get; set; }
    }
}
