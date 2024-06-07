using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobInMinuteServer.DAL;
using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;


namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller
    {

        private readonly IJobRepository _jobRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IEmployerRepository _employerRepository;

        public JobsController(IJobRepository jobRepository, ICityRepository cityRepository, IEmployerRepository employerRepository)
        {
            _jobRepository = jobRepository;
            _cityRepository = cityRepository;
            _employerRepository = employerRepository;
        }


        [HttpPost("saveJob")]
        public async Task<IActionResult> SaveJob([FromBody] Job job)
        {
            if (!await _employerRepository.Exists(job.EmployerId))
            {
                return BadRequest("Invalid employer ID. Please ensure the employer exists.");
            }

            if (!await _cityRepository.Exists(job.CityCode)) // Assuming Exists method takes cityCode argument
            {
                return BadRequest("Invalid city code. Please ensure the city exists.");
            }

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



        [HttpGet("GetJobById")]
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

        [HttpPost("UpdateJob")]
        public async Task<IActionResult> UpdateJob([FromBody] Job job)
        {
            try
            {
                await _jobRepository.UpdateJob(job);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
