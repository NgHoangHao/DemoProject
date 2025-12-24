
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookCode { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedYear { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Avatar { get; set; }
        public string Pdf { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("AuthorId")]
        public Authors? Authors { get; set; }


        [ForeignKey("CategoryId")]
        public Categories? Categories { get; set; }


        public ICollection<Loans>? Loans { get; set; }
    }
}


