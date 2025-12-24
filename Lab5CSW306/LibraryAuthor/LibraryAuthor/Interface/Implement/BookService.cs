using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthor.Interface.Implement
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        private readonly IWebHostEnvironment _env;
        public BookService(LibraryContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<bool> AddNewBookAsync(BooksDTO book)
        {
            if (book == null)
            {
                return false;
            }

            Books books = new Books()
            {
                AuthorId = book.AuthorId,
                AvailableCopies = book.AvailableCopies,
                Avatar = book.Avatar,
                BookCode = book.BookCode,
                CategoryId = book.CategoryId,
                Description = book.Description,
                CreatedDate = book.CreatedDate,
                Pdf = book.Pdf,
                Title = book.Title,
                TotalCopies = book.TotalCopies,
                IsActive = book.IsActive,
                PublishedYear = book.PublishedYear,
                Publisher = book.Publisher,

            };

            await _context.Books.AddAsync(books);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> BookPDFAsync(int id)
        {
            var result = await _context.Books.FindAsync(id);
            if (result == null)
            {
                return ("Not found book");
            }
            return (result.Pdf);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var findBook = await _context.Books.FindAsync(id);
            if (findBook == null)
            {
                return false;
            }
            findBook.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Books>> GetAllBookAsync()
        {
            var bookList = await _context.Books.ToListAsync();
            return bookList;
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var findBook = await _context.Books.FindAsync(id);
            return findBook;
        }

        public async Task<IEnumerable<Books>> GetDeletedBooksAsync()
        {
            var list = await _context.Books.Where(b => b.IsDeleted == true).ToListAsync();
            return list;
        }

        public async Task<bool> HardDeleteBookAsync(int id)
        {
            var find = await _context.Books.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            if (find.Pdf != null)
            {
                var relativePath = find.Pdf.TrimStart('/');
                var pdfPath = Path.Combine(_env.WebRootPath, relativePath);
                if (File.Exists(pdfPath))
                {
                    File.Delete(pdfPath);
                }

            }
            _context.Books.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleDeletedBookAsync(int id)
        {
            var find = await _context.Books.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            find.IsDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookAsync(int id, BooksDTO book)
        {
            var updatedBook = new Books
            {
                BookId = id,
                AuthorId = book.AuthorId,
                AvailableCopies = book.AvailableCopies,
                Avatar = book.Avatar,
                BookCode = book.BookCode,
                CategoryId = book.CategoryId,
                Description = book.Description,
                CreatedDate = book.CreatedDate,
                Pdf = book.Pdf,
                Title = book.Title,
                TotalCopies = book.TotalCopies,
                IsActive = book.IsActive,
                PublishedYear = book.PublishedYear,
                Publisher = book.Publisher
            };
            _context.Entry(updatedBook).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}

