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
            // add new user it to the DbSet
            _context.Users.Add(user);
            
            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetByMailAndPassword(string mail, string password)
        {
            // מציאת משתמש בעזרת אימייל וסיסמה
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == mail && u.Password == password);

            return user;
        }
        

    }
}
