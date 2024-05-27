using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            try
            {
                // Add the new candidate to the DbSet
                _context.Candidats.Add(candidate);

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

        public async Task<Candidate> GetCandidateById(int CandidateID)
        {
            try
            {
                var candidate = await _context.Candidats.FindAsync(CandidateID);


                if (candidate == null)
                {
                    throw new InvalidOperationException("Candidate not found.");
                }
                return candidate;
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"An error occurred while retrieving candidate with ID {CandidateID}: {ex.Message}");

                throw;
            }
        }

        public async Task<List<City>> GetCitiesByCandidateId(int candidateId)
        {
            var candidatePreferredCities = await _context.CandidatePreferedCities
                                    .Where(cpc => cpc.CandidateID == candidateId)
                                    .Select(cpc => cpc.City)
                                    .ToListAsync();

            return candidatePreferredCities ?? new List<City>();
          
        }
    }
}
