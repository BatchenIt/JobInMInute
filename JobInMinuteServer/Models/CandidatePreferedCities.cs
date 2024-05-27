using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class CandidatePreferedCity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CandidateID { get; set; } // זיהוי המועמד

        [Required]
        public int CityCode { get; set; } // קוד העיר שהועדף

        // קשר למודל המועמד
        public Candidate Candidate { get; set; }

        // קשר למודל הערים
        public City City { get; set; }
    }
}
