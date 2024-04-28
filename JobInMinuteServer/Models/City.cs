using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class City
    {
        [Key]
        public int CityCode { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
