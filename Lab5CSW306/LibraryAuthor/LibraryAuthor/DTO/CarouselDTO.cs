using System.ComponentModel.DataAnnotations;

namespace LibraryAuthor.DTO
{
    public class CarouselDTO
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string? LinkUrl { get; set; }
        [Required]
        public int Order { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }
    }
}
