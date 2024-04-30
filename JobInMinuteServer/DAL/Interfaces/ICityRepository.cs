using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByCityCode(int cityCode);
        Task SaveCity(City cityCode);
    }
}
