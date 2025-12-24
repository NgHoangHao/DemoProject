using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId {  get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Users User{ get; set;}
        public Role Role { get; set; }
    }
}
