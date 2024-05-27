using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.DAL;
using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using JobInMinuteServer.Models.JobInMinuteServer.Models.JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;


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
