using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(100)]
        public string Fullname { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9].*$")]
        [StringLength(20)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public string UserCode { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string ActiveCode { get; set; }
        public string Avatar { get; set; }
        public ICollection<UserRole> UserRoles {  get; set; }
    }
}
