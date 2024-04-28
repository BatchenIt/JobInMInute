using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL
{
    public class UserRepository: IUserRepository
    {
        private readonly JobInMinuteDbContext _context;
        public UserRepository(JobInMinuteDbContext context) {
            _context = context;
        }

        public async Task SaveUser(User user)
        {
            //if (user.ID == 0)
            //{
                // New user: Add it to the DbSet
                 _context.Users.Add(user);
            //}
            //else
            //{
            //    // Existing product: Update it (optional)
            //    _context.Users.Update(user);
            //}

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

    }
}
