using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuthor.Model
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string Name { get;set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Avatar {  get; set; }
       
        public ICollection<Books>?Books { get; set; }

    }
}
