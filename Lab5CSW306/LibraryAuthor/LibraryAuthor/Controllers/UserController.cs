using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using LibraryAuthor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> Register(UsersDTO user)
        {
            var result = await _userService.RegisterAsync(user);
            if (result)
            {

                return Ok("Register successfully");

            }
            return Ok("Register successfully");
        }
        [HttpPost("active")]
        public async Task<ActionResult> AuthenticationAccount([FromQuery] string email, [FromQuery] string activeCode)
        {
            var result = await _userService.AuthenticationAsync(email, activeCode);
            if (result)
            {
                return Ok("Account verification successfullly");
            }
            return Ok("Account verification faileed");
        }
        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMe()
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new { username, role });
        }
        [HttpGet("dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return Ok("Welcome, Admin!");
        }
        [HttpGet("active-user")]
        [Authorize(Policy= "ActiveUserOnly")]
        public async Task<ActionResult> GetAllActiveUser()
        {
            var result = await _userService.GetAllActiveUserAsync();
            if (result==null)
            {
                return NotFound("List is empty");
            }
            return Ok(result);
        }
        [HttpPost("add-role")]
        public async Task<ActionResult> AddRoleForUser([FromBody] UserRoleDTO role)
        {
            var result = await _userService.AddRoleForUser(role);
            if (!result)
            {
                return BadRequest("Invalid information");
            }
            return Ok("User is registed with this role");
        }

    }

}

