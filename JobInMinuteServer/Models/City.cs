using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.Models;
using System.Collections.Generic;
using System;

namespace JobInMinuteServer.Models
{
    public class City
    {
        [Key]
        public int CityCode { get; set; }

        [Required, StringLength(50)]
        public string CityName { get; set; }

    }
}
