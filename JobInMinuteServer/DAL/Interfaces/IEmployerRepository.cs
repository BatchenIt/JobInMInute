using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IEmployerRepository
    {
        Task<Employer> GetEmployerById(int employerId);
        Task SaveEmployer(Employer employer);
    }
}
