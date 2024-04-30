using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobInMinuteDbContext _context;

        public CandidateRepository(JobInMinuteDbContext context)
        {
            _context = context;
        }

        public async Task SaveCandidate(Candidate candidate)
        {
            // New user: Add it to the DbSet
            _context.Candidats.Add(candidate);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            return await _context.Candidats.FindAsync(candidateId);
        }
       
    }
}
