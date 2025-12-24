using LibraryAuthor.DTO;
using LibraryAuthor.Model;
namespace LibraryAuthor.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync(bool isActive, string? name);
        Task<bool> AddNewCategoryAsync(CategoriesDTO category);
        Task<bool> UpdateCategoryAsync(int id, CategoriesDTO category);
        Task<bool> ToggleCategoryAsync(int id);
        
    }
}
