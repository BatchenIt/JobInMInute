using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL
{
    public class CityRepository : ICityRepository
    {
        private readonly JobInMinuteDbContext _context;
        public CityRepository(JobInMinuteDbContext context)
        {
            _context = context;
        }

        public async Task SaveCity(City city)
        {
          
            // New city: Add it to the DbSet
            _context.Cities.Add(city);
            
            // Save changes to the database
            await _context.SaveChangesAsync();
        }
        public async Task<City> GetCityByCityCode(int cityCod)
        {
            return await _context.Cities.FindAsync(cityCod);
        }
    }
}
