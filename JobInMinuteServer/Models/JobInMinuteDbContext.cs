using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;


namespace JobInMinuteServer.Models
{
    public class JobInMinuteDbContext : DbContext
    {
        public JobInMinuteDbContext(DbContextOptions<JobInMinuteDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CandidateJobs> CandidateJobs { get; set; }
        public DbSet<CandidatePreferedCities> CandidatePreferedCities { get; set; }
        public DbSet<EmployerReview> EmployerReviews { get; set; }
        public DbSet<CandidateJobReview> CandidateJobReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CandidateJobs>()
                .HasKey(cj => new { cj.CandidateID, cj.JobID }); //הגדרת מפתח ראשי מורכב

            //modelBuilder.Entity<CandidateJobs>() //הגדרת הקשר Many-to-One
            //    .HasOne(cj => cj.Candidate)
            //    .WithMany(c => c.Jobs)
            //    .HasForeignKey(cj => cj.CandidateID);



            modelBuilder.Entity<CandidateJobs>() //הגדרת הקשר Many-to-One
                .HasOne(cj => cj.Job)
                .WithMany()
                .HasForeignKey(cj => cj.JobID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CandidatePreferedCities>()
                .HasKey(cpc => new { cpc.CandidateID, cpc.CityCode });

            //modelBuilder.Entity<CandidatePreferedCities>()
            //    .HasOne(cpc => cpc.Candidate)
            //    .WithMany(c => c.cities)
            //    .HasForeignKey(cpc => cpc.CandidateID);

            modelBuilder.Entity<CandidatePreferedCities>()
                .HasOne(cpc => cpc.City)
                .WithMany()
                .HasForeignKey(cpc => cpc.CityCode);
        }

    }
}
