using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface ICityRepository
    {
        Task SaveCity(City city);
        Task<City> GetCityByCityCode(int cityCode);
        Task<City> GetCityByCityName(string cityName);
        Task<bool> Exists(int cityCode);
        Task<List<City>> GetCities();
        
    }
}
