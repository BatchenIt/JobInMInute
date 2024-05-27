using JobInMinuteServer.DAL;
using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Migrations;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;


        public CandidatesController(ICandidateRepository candidateRepository, IUserRepository userRepository, ICityRepository cityRepository)
        {
            _candidateRepository = candidateRepository;
            _userRepository= userRepository;
            _cityRepository = cityRepository;
        }


        [HttpPost(Name = "saveCandidats")]

        public async Task<IActionResult> SaveCandidats([FromBody] Candidate candidate)
        {
            try
            {
                await _candidateRepository.SaveCandidate(candidate);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpGet(Name = "GetCandidate")]
        public async Task<IActionResult> GetCandidateById(int CandidateID)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetCandidateById(CandidateID);
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet("GetCitiesByCandidateId")]
        public async Task<IActionResult> GetCitiesByCandidateId(int candidateId)
        {
            try
            {
                List<City> cities = await _candidateRepository.GetCitiesByCandidateId(candidateId);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }

}
