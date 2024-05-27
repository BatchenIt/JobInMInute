using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL
{
    public class JobRepository : IJobRepository
    {
        private readonly JobInMinuteDbContext _context;
        public JobRepository(JobInMinuteDbContext context)
        {
            _context = context;
        }


        public async Task SaveJob(Job job)
        {
            try
            {
                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"An error occurred while saving the job: {ex.Message}");
                throw;
            }
          
        }

        public async Task<Job> GetJobById(int jobId)
        {
            return await _context.Jobs.FindAsync(jobId);
        }

        public async Task UpdateJob(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

   /*     public async Task<List<Job>> GetJobsByCandidateId(int candidateId, string location)
        {
            location ??= null; //אם ריק  null אם מלא אז נשאר

            var preferredCities = await _context.CandidatePreferedCities
                .Where(c => c.CandidateID == candidateId)
                .Select(c => c.CityCode)
                .ToListAsync();

            if (!string.IsNullOrEmpty(location))
            {
                preferredCities.Add(location);
            }

            var jobsInPreferredCities = await _context.Jobs
                .Where(j => preferredCities.Contains(j.Address))
                .ToListAsync();

            return jobsInPreferredCities;
        }*/
    }
}

