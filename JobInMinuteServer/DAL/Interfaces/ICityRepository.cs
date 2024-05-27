using JobInMinuteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByCityCode(int cityCode);
        Task SaveCity(City city);
        Task<List<City>> GetCities();
    }
}
