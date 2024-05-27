using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;



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
    public DbSet<CandidatePreferedCity> CandidatePreferedCities { get; set; }


   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define the relationship between Candidate and User
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        // Define the relationship between Employer and User
        modelBuilder.Entity<Employer>()
            .HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CandidatePreferedCity>()
             .HasOne(cpc => cpc.City)
             .WithMany()
             .HasForeignKey(cpc => cpc.CityCode)
             .OnDelete(DeleteBehavior.Cascade);

        // Define the relationship between CandidatePreferedCity and Candidate
        modelBuilder.Entity<CandidatePreferedCity>()
            .HasOne(cpc => cpc.Candidate)
            .WithMany()
            .HasForeignKey(cpc => cpc.CandidateID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Job>()
            .HasOne(c => c.Employer)
            .WithMany()
            .HasForeignKey(c => c.EmployerId)
            .OnDelete(DeleteBehavior.Cascade);

    }

}
