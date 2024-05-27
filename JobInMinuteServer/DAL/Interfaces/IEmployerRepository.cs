using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IEmployerRepository
    {
        Task<Employer> GetEmployerById(int employerId);
        Task SaveEmployer(Employer employer);
        Task<List<Job>> GetJobsByEmployerId(int employerId);


    }
}
