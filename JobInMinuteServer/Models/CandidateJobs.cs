using JobInMinuteServer.Models.JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class CandidateJobs
    {
        [Key]
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        [Required]
        //public int JobID { get; set; }
        public IEnumerable<Job> Job { get; set; }
    }
}
