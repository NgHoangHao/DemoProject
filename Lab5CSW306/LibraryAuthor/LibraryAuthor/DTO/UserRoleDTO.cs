using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.DTO
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
