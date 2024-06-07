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
        //public async Task<Candidate> UpdateCandidateWithUser(int id, Candidate candidate)
        //{
        //    var existingCandidate = await _context.Candidats.Include(c => c.User).SingleOrDefaultAsync(c => c.ID == id);
        //    if (existingCandidate == null)
        //    {
        //        return null;
        //    }

        //    // Ensure the UserId and User.ID are not changed
        //    if (existingCandidate.UserId != candidate.UserId || existingCandidate.User.ID != candidate.User.ID)
        //    {
        //        throw new InvalidOperationException("Cannot change the UserId or User.ID of a candidate.");
        //    }

        //    _context.Entry(existingCandidate.User).CurrentValues.SetValues(candidate.User);
        //    _context.Entry(existingCandidate).CurrentValues.SetValues(candidate);
        //    await _context.SaveChangesAsync();
        //    return existingCandidate;
        //}
        //public async Task<Candidate> GetCandidateByIdIncludingUser(int id)
        //{
        //    // טעינה אגרסיבית של המועמד והמשתמש המקושר אליו
        //    return await _context.Candidats.Include(c => c.User).SingleOrDefaultAsync(c => c.ID == id);
        //}


        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            return await _context.Candidats.FindAsync(candidateId);
            //  return await _context.Candidats
            //   .Include(c => c.User)
            //.FirstOrDefaultAsync(c => c.ID == candidateId);

        }
       
    }
}
