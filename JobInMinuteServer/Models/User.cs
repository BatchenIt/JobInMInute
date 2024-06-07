using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobInMinuteServer.Models
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isEmployer { get; set; }
    }
}
