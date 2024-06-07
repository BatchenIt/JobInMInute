using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobInMinuteServer.Models
{
    public class User
    {

        [Key]
        public int UserID { get; set;}

        [Required,StringLength(30)]
        public string Name { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required,Phone]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        [Required,MinLength(8)]
        public string Password { get; set; }
        public bool isEmployer { get; set; }
    }
}
