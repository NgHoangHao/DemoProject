using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class Authors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [StringLength(100)]
        public string FirstName {  get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography {  get; set; }
        [StringLength(100)]
        public string Nationality {  get; set; }
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
        public ICollection<Books>?Books { get; set; }
    }
}
