using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
 
   public interface ICandidateRepository
        {
            Task<Candidate> GetCandidateById(int candidateId);
            Task SaveCandidate(Candidate candidate);
        }
    
}

