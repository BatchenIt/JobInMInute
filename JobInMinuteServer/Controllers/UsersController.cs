using JobInMinuteServer.DAL.Interfaces;
using JobInMinuteServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobInMinuteServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("saveUser")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is missing.");
            }
            try
            {
                await _userRepository.SaveUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try {
                User user = await _userRepository.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string mail, string password)
        {
            try
            {
                // אתה יכול להשתמש באינטרפייס או כל מימוש של מחלקת מנהל המשתמשים כדי לבדוק את האימייל והסיסמה
                // לדוגמה, נניח שיש לך מחלקה המייצגת מסד נתונים של משתמשים, והיא מכילה את הפעולה GetByMailAndPassword
                // שמחזירה את המשתמש על פי האימייל והסיסמה הנתונים
                User user = await _userRepository.GetByMailAndPassword(mail, password);

                if (user != null)
                {
                    // אם המשתמש נמצא, המערכת תחזיר אותו כתוצאה מוצלחת
                    return Ok(user);
                }
                else
                {
                    // אם המשתמש לא נמצא, תחזיר תגובת שגיאה מתאימה
                    return NotFound("Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                // אם משהו השתבש בתהליך, תחזיר תגובת שגיאה
                return BadRequest(ex.ToString());
            }
        }

        
    }
}
