using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task SaveUser(User user);
        Task<User> GetUserById(int userId);
        Task<User> GetByMailAndPassword(string mail, string password);
        
    }
}
