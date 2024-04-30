using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller
    {

        private readonly IJobRepository _jobRepository;

        public JobsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }


        [HttpPost(Name = "saveJob")]
        public async Task<IActionResult> SaveJob([FromBody] Job job)
        {
            try
            {
                await _jobRepository.SaveJob(job);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet(Name = "getJob")]
        public async Task<IActionResult> GetJobById(int jobId)
        {
            try
            {
                Job job = await _jobRepository.GetJobById(jobId);
                return Ok(job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}