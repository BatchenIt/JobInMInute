using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class Candidate
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public float Experience { get; set; }
        public string Education { get; set; }
        public string Interests { get; set; }
        public string Resume { get; set; }
        public bool Mobility { get; set; }
        public string LinkedIn { get; set; }
    }
}
