using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
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
            
            _context.Jobs.Add(job);
          
            await _context.SaveChangesAsync();
        }
        public async Task<Job> GetJobById(int jobId)
        {
            return await _context.Jobs.FindAsync(jobId);
        }
    }
}
