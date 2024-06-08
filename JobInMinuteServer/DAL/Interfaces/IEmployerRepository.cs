using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IEmployerRepository
    {

        Task SaveEmployer(Employer employer);
        Task<Employer> GetEmployerById(int employerId);
        Task<bool> Exists(int employerId);
        Task<List<Job>> GetJobsByEmployerId(int employerId);
        

    }
}
