using System.ComponentModel.DataAnnotations;

namespace LibraryAuthor.DTO
{
    public class LoansDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Range(0, 2)]
        public int Status { get; set; }
    }
}
