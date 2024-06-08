using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace JobInMinuteServer.DAL.Interfaces
{

    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateById(int CandidateID);
        Task SaveCandidate(Candidate candidate);
        Task<List<City>> GetCitiesByCandidateId(int candidateId);
        Task<List<Job>> GetJobsByCandidateId(int candidateId, int location);
        Task SetPreferredCities(int candidateId, int cityCode); 

    }

}


