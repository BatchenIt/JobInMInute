using JobInMinuteServer.DAL;
using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployersController : Controller
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IUserRepository _userRepository;


        public EmployersController(IEmployerRepository employerRepository, IUserRepository userRepository)
        {
            _employerRepository = employerRepository;
            _userRepository = userRepository;
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

        [HttpGet("GetJobsByEmployerId")]
        public async Task<IActionResult> GetJobsByEmployerId(int employerId)
        {
            try
            {
                List<Job> jobs = await _employerRepository.GetJobsByEmployerId(employerId);
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }
    }
}
