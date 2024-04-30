using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployersController : Controller
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployersController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }


        [HttpPost(Name = "saveEmployer")]
        public async Task<IActionResult> SaveEmployer([FromBody] Employer employer)
        {
            try
            {
                await _employerRepository.SaveEmployer(employer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet(Name = "getEmployer")]
        public async Task<IActionResult> GetEmployerById(int employerId)
        {
            try
            {
                Employer employer = await _employerRepository.GetEmployerById(employerId);
                return Ok(employer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
