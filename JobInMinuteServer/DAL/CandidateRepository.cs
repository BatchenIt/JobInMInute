using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;
using JobInMinuteServer.DAL.Interfaces;
//using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;


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
            if (candidate.User.isEmployer == true)
            {
                throw new InvalidOperationException("Employers cannot register as candidates.");
            }

            try
            {
                // Add the new candidate to the DbSet
                _context.Candidates.Add(candidate);
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"An error occurred while saving the candidate: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Exists(int CandidateID)
        {
            return await _context.Candidates.AnyAsync(e => e.CandidateID == CandidateID);
        }

        public async Task<List<City>> GetCitiesByCandidateId(int candidateId)
        {
            var candidatePreferredCities = await _context.CandidatePreferedCities
                                    .Where(cpc => cpc.CandidateID == candidateId)
                                    .Include(cpc => cpc.City) // Include the City objects
                                    .ToListAsync();

            // Extract and return the list of City objects
            return candidatePreferredCities.Select(cpc => cpc.City).ToList();
        }


        public async Task<List<Job>> GetJobsByCandidateId(int candidateId, int location)
        {
            if (location == null || location == 0)
            {
                var preferredCities = await _context.CandidatePreferedCities
                    .Where(cpc => cpc.CandidateID == candidateId)
                    .Select(cpc => cpc.City.CityCode)
                    .ToListAsync();

                var jobs = await _context.Jobs
                    .Where(job => preferredCities.Contains(job.CityCode))
                    .ToListAsync();

                return jobs;
            }
            else
            {
                var jobs = await _context.Jobs
                    .Where(job => job.CityCode == location)
                    .ToListAsync();

                return jobs;
            }
        }


        public async Task SetPreferredCities(int candidteId, int CityCode)
        {
            try
            {
                // Create a new CandidatePreferredCities instance
                var candidatePreferredCity = new CandidatePreferedCities
                {
                    CandidateID = candidteId,
                    CityCode = CityCode
                };
                // Save changes to the database
                await _context.SaveChangesAsync();
                // Add the new instance to the DbSet
                _context.CandidatePreferedCities.Add(candidatePreferredCity);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"An error occurred while saving the CandidatePreferredCities: {ex.Message}");
                throw;
            }

        }

        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            return await _context.Candidates.FindAsync(candidateId);
            //  return await _context.Candidats
            //   .Include(c => c.User)
            //.FirstOrDefaultAsync(c => c.ID == candidateId);

        }

        //public async Task<Candidate> GetCandidateById(int CandidateID)
        //{
        //    try
        //    {
        //        var candidate = await _context.Candidates.FindAsync(CandidateID);


        //        if (candidate == null)
        //        {
        //            throw new InvalidOperationException("Candidate not found.");
        //        }
        //        return candidate;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the error for debugging
        //        Console.WriteLine($"An error occurred while retrieving candidate with ID {CandidateID}: {ex.Message}");

        //        throw;
        //    }
        //}

    }
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
