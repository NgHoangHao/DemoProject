using System.ComponentModel.DataAnnotations;

namespace LibraryAuthor.DTO
{
    public class BorrowBooksDTO
    {
        public int BookId { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public int BorrowedTime { get; set; }
    }
}
