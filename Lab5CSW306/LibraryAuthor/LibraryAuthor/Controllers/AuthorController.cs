using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using LibraryAuthor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public AuthorController(IUserService userService, IConfiguration config, LibraryContext context)
        {
            _userService = userService;
            _config = config;
            _context = context;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest user)
        {
            var result = await _userService.LoginAsync(user);
            if (result == null)
            {
                return NotFound("Sai ten hoac mat khau");
            }
            var token = GenerateJwtToken(result);
            return Ok(token);
        }
        private string GenerateJwtToken(Users user)
        {

            var roles = _context.UserRole
                .Where(ur => ur.UserId == user.UserId)
                .Select(ur => ur.Role.RoleName)
                .ToList();
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Fullname),
        new Claim(ClaimTypes.Email,user.Email),
        new Claim("IsActive",user.IsActive.ToString().ToLower()),
        new Claim("RegistrationDate", user.CreatedDate.ToString("O")),
        new Claim("CanManageCategories","True")
    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
