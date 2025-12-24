using System.ComponentModel.DataAnnotations;

namespace LibraryAuthor.Model
{
    public class Role
    {
        [Key]
        public int RoleId {  get; set; }
        public string RoleName { get; set; }
        public string Description {  get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
