using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthor.Interface.Implement
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _context;
        public AuthorService (LibraryContext context) 
        {
            _context = context;
        }

        public async Task<bool> AddNewAuthorAsync(AuthorsDTO author)
        {
            if(author == null)
            {
                return false;
            }
            Authors authors = new Authors()
            {
                Avatar = author.Avatar,
                Biography=author.Biography,
                CreatedDate=author.CreatedDate,
                DateOfBirth=author.DateOfBirth,
                Email= author.Email,
                FirstName=author.FirstName,
                IsActive = author.IsActive,
                LastName = author.LastName,
                Nationality = author.Nationality,
                Website = author.Website
                
            };

            await _context.Authors.AddAsync(authors);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var findAuthor= await _context.Authors.FindAsync(id);
            if(findAuthor == null){
                return false;
            }
            findAuthor.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync(string name)
        {

            if (name == null) {
                var list = await _context.Authors.ToListAsync();
                return list;
            }
            var authorList= await _context.Authors.Where(p=>(p.FirstName.ToString() +" "+p.LastName.ToString()).Equals(name)).ToListAsync();
            return authorList;
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var findAuthor = await _context.Authors.FindAsync(id);
            return findAuthor;
        }

        public async Task<bool> UpdateAuthorAsync(int id, AuthorsDTO author)
        {
            Authors authors = new Authors()
            {
                AuthorId= id,
                Avatar = author.Avatar,
                Biography = author.Biography,
                CreatedDate = author.CreatedDate,
                DateOfBirth = author.DateOfBirth,
                Email = author.Email,
                FirstName = author.FirstName,
                IsActive = author.IsActive,
                LastName = author.LastName,
                Nationality = author.Nationality,
                Website = author.Website

            };
            _context.Entry(authors).State= EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateConcurrencyException)
            {
                return false;
            }
            
        }
    }
}
