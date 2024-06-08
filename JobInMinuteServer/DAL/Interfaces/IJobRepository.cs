using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IJobRepository
    {
        Task SaveJob(Job job);
        //Task<Job> GetJobById(int jobId);
        Task UpdateJob(Job job); // Add this line

    }
}
