using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IJobRepository
    {
        Task SaveJob(Job job);
        Task<Job> GetJobById(int jobId);
      

        // Task UpdateJob(Job job);
        // Task<List<Job>> GetJobsByCandidateId(int candidateId, string location);

    }
}
