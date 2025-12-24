using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class Loans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId {  get; set; }
        public int UserId { get; set; }
        public int BookId {  get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LoanDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }
        [Range(0,2)]
        public int Status { get; set; }
        [ForeignKey("BookId")]
        public Books?  Books { get; set; }
        [ForeignKey("UserId")]
 
        public Users? Users { get; set; }
      
    }
}
