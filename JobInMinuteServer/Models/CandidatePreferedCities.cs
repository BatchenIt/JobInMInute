using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class CandidatePreferedCities
    {
        [Key]
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
