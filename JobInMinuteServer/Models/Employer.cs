using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.Models;
using System.Collections.Generic;
using System;

namespace JobInMinuteServer.Models
{
    public class Employer
    {
        [Key, ForeignKey("User")]
        public int EmployerID { get; set; }

        public User? User { get; set; }

        [Required, StringLength(9)]
        public string BN_number { get; set; }

        [Required, StringLength(50)]
        public string CompanyName { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required,StringLength(25)]
        public string Businessfield { get; set; }

    }


}
