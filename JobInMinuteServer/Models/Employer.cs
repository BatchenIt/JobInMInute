using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobInMinuteServer.Models
{
    public class Employer
    {
        [Key]
        public int EmployerID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

        public string BN_number { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Description { get; set; }

        public string Businessfield { get; set; }
    }

   
}
