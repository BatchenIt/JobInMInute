using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using JobInMinuteServer.Migrations;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly JobInMinuteDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        public CandidatesController(ICandidateRepository candidateRepository, JobInMinuteDbContext context, IUserRepository userRepository, IEmailSender emailSender, IJobRepository jobRepository, IEmployerRepository employerRepository)
        {
            _candidateRepository = candidateRepository;
            _context = context;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _jobRepository = jobRepository;
            _employerRepository = employerRepository;


        }
        //[HttpGet("EMAIL")]
        //public async Task<IActionResult> Index()
        //{

        //    var reciver = "gilad.skop@gmail.com";
        //    var subject = "test";
        //    var message = "hello world";
        //    await _emailSender.SendEmailAsync(reciver, subject, message);
        //    return View();
        //}






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
        //[HttpPut("UpdateCandidate/{id}")]
        //public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        //{
        //    if (candidate == null || id != candidate.ID)
        //    {
        //        return BadRequest("Mismatch between URL ID and candidate ID or candidate object is null.");
        //    }

        //    // Retrieve the existing candidate along with the associated user
        //    var existingCandidate = await _candidateRepository.UpdateCandidateWithUser(id,candidate);
        //    if (existingCandidate == null)
        //    {
        //        return NotFound($"Candidate with ID {id} not found.");
        //    }

        //    // Check that the user ID has not been changed
        //    if (existingCandidate.UserId != candidate.UserId)
        //    {
        //        return BadRequest("User ID cannot be changed.");
        //    }

        //    // Check that the User ID within User object has not been changed
        //    if (existingCandidate.User.ID != candidate.User.ID)
        //    {
        //        return BadRequest("User's ID within User object cannot be changed.");
        //    }

        //    try
        //    {
        //        // Update user details
        //        _context.Entry(existingCandidate.User).CurrentValues.SetValues(candidate.User);
        //        // Update candidate details
        //        _context.Entry(existingCandidate).CurrentValues.SetValues(candidate);

        //        await _context.SaveChangesAsync();
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error updating candidate: {ex.Message}");
        //    }
        //}
        //[HttpPut("UpdateCandidate/{id}/{userId}")]
        //public async Task<IActionResult> UpdateCandidate(int id, int userId, [FromBody] Candidate candidate)
        //{
        //    if (candidate == null || id != candidate.ID || userId != candidate.UserId)
        //    {
        //        return BadRequest("Mismatch in IDs or candidate object is null.");
        //    }

        //    var existingCandidate = await _candidateRepository.GetCandidateByIdIncludingUser(id);
        //    if (existingCandidate == null)
        //    {
        //        return NotFound($"Candidate with ID {id} not found.");
        //    }

        //    if (existingCandidate.UserId != userId || existingCandidate.User.ID != candidate.User.ID)
        //    {
        //        return BadRequest("Cannot change the UserId or User's ID within the candidate.");
        //    }

        //    if (existingCandidate.User.isEmployer != candidate.User.isEmployer)
        //    {
        //        return BadRequest("Cannot change the isEmployer status.");
        //    }

        //    _context.Entry(existingCandidate.User).CurrentValues.SetValues(candidate.User);
        //    _context.Entry(existingCandidate).CurrentValues.SetValues(candidate);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error updating candidate: {ex.Message}");
        //    }
        //}
        //[HttpPost]
        //[Route("ApplyToJob / {candidateId} / {jobId}")]
        //public async Task<IActionResult> ApplyToJob(int candidateId, int jobId)
        //{
        //    try
        //    {
        //        // Retrieve candidate and job from the database
        //        Candidate my_candidate = await _candidateRepository.GetCandidateById(candidateId);
        //        Job my_job = await _jobRepository.GetJobById(jobId);

        //        if (my_candidate == null || my_job == null)
        //        {
        //            return NotFound("Candidate or Job not found.");
        //        }

        //        // Compose the email
        //        string subject = "New Job Application";
        //        string body = $"Candidate {my_candidate.User.Name} has applied for the job {my_job.Title}.";
        //        string employerEmail = my_job.Employer.User.Email;

        //        // Send the email
        //        await _emailSender.SendEmailAsync(employerEmail, subject, body);

        //        return Ok("Application submitted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}

        //    [HttpPost]
        //    [Route("SendEmail")]
        //    public async Task<IActionResult> SendEmail(string to, string subject, string body)
        //    {
        //        try
        //        {
        //            await _emailSender.SendEmailAsync(to, subject, body);
        //            return Ok("Email sent successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest($"Error: {ex.Message}");
        //        }
        //    }

        [HttpPut("UpdateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            if (candidate == null || id != candidate.ID)
            {
                return BadRequest("Mismatch between URL ID and candidate ID or candidate object is null.");
            }

            // Retrieve the existing candidate
            var existingCandidate = await _candidateRepository.GetCandidateById(id);
            if (existingCandidate == null)
            {
                return NotFound($"Candidate with ID {id} not found.");
            }

            // Retrieve the associated user directly if needed
            var existingUser = await _context.Users.FindAsync(existingCandidate.UserId);
            if (existingUser == null)
            {
                return NotFound("Associated user not found.");
            }

            // Ensure the UserId and User.ID are not changed
            if (existingCandidate.UserId != candidate.UserId || existingUser.ID != candidate.User.ID)
            {
                return BadRequest("User IDs cannot be changed.");
            }

            if (existingUser.isEmployer != candidate.User.isEmployer)
            {
                return BadRequest("Employment status cannot be changed.");
            }

            // Update user details
            _context.Entry(existingUser).CurrentValues.SetValues(candidate.User);
            // Update candidate details
            _context.Entry(existingCandidate).CurrentValues.SetValues(candidate);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating candidate: {ex.Message}");
            }
        }
        [HttpPut("UpdateEmployer/{id}")]
        public async Task<IActionResult> UpdateEmployer(int id, [FromBody] Employer employer)
        {
            if (employer == null || id != employer.ID)
            {
                return BadRequest("Mismatch between URL ID and employer ID or employer object is null.");
            }

            var existingEmployer = await _employerRepository.GetEmployerById(id);
            if (existingEmployer == null)
            {
                return NotFound($"Employer with ID {id} not found.");
            }

            if (existingEmployer.UserId != employer.UserId)
            {
                return BadRequest("User ID cannot  be changed.");
            }

            var existingUser = await _userRepository.GetUserById(employer.UserId);
            if (existingUser == null)
            {
                return NotFound("Associated user not found.");
            }

            if (existingUser.isEmployer != employer.User.isEmployer)
            {
                return BadRequest("Cannot change the 'isEmployer' status.");
            }

            try
            {
                // Update user details
                _context.Entry(existingUser).CurrentValues.SetValues(employer.User);
                // Update employer details
                _context.Entry(existingEmployer).CurrentValues.SetValues(employer);

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating employer: {ex.Message}");
            }
        }



    }
}
