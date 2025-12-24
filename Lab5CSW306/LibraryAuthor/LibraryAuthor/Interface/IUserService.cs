using LibraryAuthor.DTO;
using LibraryAuthor.Model;

namespace LibraryAuthor.Interface
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UsersDTO user);
        Task<bool> AuthenticationAsync(string email, string activeCode);
        Task<Users?> LoginAsync(LoginRequest user);
        Task<IEnumerable<Users>> GetAllActiveUserAsync();
        Task<bool> AddRoleForUser(UserRoleDTO role);
    }
}
