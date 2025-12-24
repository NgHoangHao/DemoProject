using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LibraryAuthor.Interface.Implement
{
    public class UserService : IUserService

    {
        private readonly LibraryContext _context;
        public UserService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRoleForUser(UserRoleDTO role)
        {
            
            if(role == null)
            {
                return false;
            }
            var newUserRole = new UserRole() { 
            RoleId= role.RoleId,
            UserId = role.UserId
            };
            await _context.UserRole.AddAsync(newUserRole);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AuthenticationAsync(string email, string activeCode)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (findUser == null)
            {
                return false;
            }
            if (findUser.ActiveCode == activeCode)
            {
                findUser.IsActive = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Users>> GetAllActiveUserAsync()
        {
            var list = await _context.Users.Where(u => u.IsActive==true).ToListAsync();
            return list;
        }

        public async Task<Users?> LoginAsync(LoginRequest user)
        {
            var find = await _context.Users.FirstOrDefaultAsync(u => u.Fullname.Equals(user.UserName));
            if (find == null)
            {
                return null;
            }
            var result = BCrypt.Net.BCrypt.Verify(user.Password, find.Password);
            if (result == false)
            {
                return null;
            }
            return find;
        }

        public async Task<bool> RegisterAsync(UsersDTO user)
        {
            if (user == null)
            {
                return false;
            }
            var findUser = _context.Users.FirstOrDefault(p => p.Email.Equals(user.Email));
            if (findUser != null)
            {
                return false;
            }
            Users users = new Users()
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Password = user.Password,
                Address = user.Address,
                Avatar = user.Avatar,
                CreatedDate = DateTime.Now,
                Description = user.Description,
                IsActive = false,
                IsDeleted = false,
                IsLocked = false,
                Phone = user.Phone,
                Status = 1,
                UserCode = user.UserCode
            };
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
            byte[] bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            int number = BitConverter.ToInt32(bytes, 0);
            number = Math.Abs(number % 1000000);
            users.ActiveCode = number.ToString("D6");
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            Console.WriteLine("Send to email: " + users.Email);
            return true;
        }
    }
}
