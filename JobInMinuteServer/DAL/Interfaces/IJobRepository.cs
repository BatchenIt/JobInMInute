using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> GetJobById(int jobId);
        Task SaveJob(Job job);
    }
}