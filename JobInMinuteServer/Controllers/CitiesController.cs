using JobInMinuteServer.DAL;
using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

       
        [HttpPost]
        [Route("saveCity")]
        public async Task<IActionResult> SaveCity([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("City data is missing.");
            }
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


        [HttpGet("GetCities")]
        public async Task<ActionResult<List<City>>> GetCities()
        {
            var cities = await _cityRepository.GetCities();
            return Ok(cities);
        }
    }
}
