using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class Employer
    {
        [Key]
        public int ID { get; set; }
        public string BN_number { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}
