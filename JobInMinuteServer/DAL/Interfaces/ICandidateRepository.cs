using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;


namespace JobInMinuteServer.DAL.Interfaces
{
 
   public interface ICandidateRepository
    {
            Task<Candidate> GetCandidateById(int CandidateID);
            Task SaveCandidate(Candidate candidate);
            Task<List<City>> GetCitiesByCandidateId(int candidateId);

    }

}
 

