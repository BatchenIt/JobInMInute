using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            // add new city it to the DbSet
            _context.Cities.Add(city);
            
            // save changes to the database
            await _context.SaveChangesAsync();
        }


        public async Task<City> GetCityByCityCode(int cityCod)
        {
            return await _context.Cities.FindAsync(cityCod);
        }


        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
