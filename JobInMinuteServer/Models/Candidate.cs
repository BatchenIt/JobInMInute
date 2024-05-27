using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobInMinuteServer.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

        public float Experience { get; set; }
        public string Education { get; set; }
        public string Interests { get; set; }
        public string Resume { get; set; }
        public bool Mobility { get; set; }
        public string LinkedIn { get; set; }
    }
}
