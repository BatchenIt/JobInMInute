using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace JobInMinuteServer.Models
{
    public class JobInMinuteDbContext : DbContext
    {
        public JobInMinuteDbContext(DbContextOptions<JobInMinuteDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidats { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CandidateJobs> CandidateJobs { get; set; }
        public DbSet<CandidatePreferedCities> CandidatePreferedCities { get; set; }


    }
}
