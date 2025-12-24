using System.ComponentModel.DataAnnotations;

namespace LibraryAuthor.DTO
{
    public class UsersDTO
    {
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
        public string UserCode { get; set; }

        public string Avatar { get; set; }
    }
}
