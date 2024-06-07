using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.Models;
using System.Collections.Generic;
using System;

namespace JobInMinuteServer.Models
{
    public class CandidatePreferedCities
    {
        [Key, Column(Order = 0), ForeignKey("Candidate")]
        public int CandidateID { get; set; } // זיהוי המועמד
        public Candidate? Candidate { get; set; }   // קשר למודל המועמד

        [Key, Column(Order =1),ForeignKey ("City")]
        public int CityCode { get; set; } // קוד העיר שהועדף
        public City? City { get; set; }    // קשר למודל הערים
    }
}
