using LibraryAuthor.DTO;
using LibraryAuthor.Model;

namespace LibraryAuthor.Interface
{
    public interface IAuthorService
    {
        Task<IEnumerable<Authors>> GetAllAuthorsAsync(String name);
        Task<Authors> GetAuthorByIdAsync(int id);
        Task<bool> AddNewAuthorAsync(AuthorsDTO author);
        Task<bool> UpdateAuthorAsync(int id, AuthorsDTO author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
