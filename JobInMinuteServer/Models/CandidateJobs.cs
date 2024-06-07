using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.Models;
using System.Collections.Generic;
using System;

namespace JobInMinuteServer.Models
{
    public class CandidateJobs
    {
        [Key, Column(Order = 0),ForeignKey("Candidate")]
        public int CandidateID { get; set; }
        public Candidate? Candidate { get; set; }

        [Key, Column(Order = 1), ForeignKey("Job")]
        public int JobID { get; set; }
        public Job? Job { get; set; }
    }
}
