using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly JobInMinuteDbContext _context;
        public EmployerRepository(JobInMinuteDbContext context)
        {
            _context = context;
        }

        public async Task SaveEmployer(Employer employer)
        {
          
            // New user: Add it to the DbSet
            _context.Employers.Add(employer);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
        public async Task<Employer> GetEmployerById(int employerId)
        {
            return await _context.Employers.FindAsync(employerId);
        }

    }
}
