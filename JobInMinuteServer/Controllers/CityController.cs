using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }


        [HttpPost(Name = "saveCity")]
        public async Task<IActionResult> SaveCity([FromBody] City city)
        {
            try
            {
                await _cityRepository.SaveCity(city);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet(Name = "getCity")]
        public async Task<IActionResult> GetCityByCityCode(int cityCode)
        {
            try
            {
                City city = await _cityRepository.GetCityByCityCode(cityCode);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
