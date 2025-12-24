namespace LibraryAuthor.DTO
{
    public class CategoriesDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
    }
}
