using LibraryAuthor.DTO;
using LibraryAuthor.Model;

namespace LibraryAuthor.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Books>> GetAllBookAsync();
        Task<Books> GetBookByIdAsync(int id);
        Task<bool> AddNewBookAsync(BooksDTO book);
        Task<bool> UpdateBookAsync(int id, BooksDTO book);
        Task<bool> DeleteBookAsync(int id);
        Task<string> BookPDFAsync(int id);
        Task<IEnumerable<Books>> GetDeletedBooksAsync();
        Task<bool> ToggleDeletedBookAsync(int id);
        Task<bool> HardDeleteBookAsync(int id);
    }
}
