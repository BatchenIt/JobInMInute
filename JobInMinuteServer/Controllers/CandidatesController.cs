using JobInMinuteServer.DAL.Interfaces;
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

        public CandidatesController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }


        [HttpPost(Name = "saveCandidates")]

        public async Task<IActionResult> SaveCandidates([FromBody] Candidate candidate)
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

        [HttpGet(Name = "getCandidate")]
        public async Task<IActionResult> GetCandidateById(int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetCandidateById(candidateId);
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
