using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthor.Interface.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryContext _context;
        public CategoryService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNewCategoryAsync(CategoriesDTO category)
        {
            if (category == null)
            {
                return false;
            }
            Categories categories = new Categories()
            {
                Name = category.Name,
                Avatar = category.Avatar,
                CreatedDate = DateTime.Now,
                Description = category.Description,
                IsActive = category.IsActive,
                UpdatedDate = DateTime.Now,
            };
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync(bool isActive, string? name)
        {
            var list = await _context.Categories.ToListAsync();
            if (isActive)
            {
                list = list.Where(l => l.IsActive == true).ToList();
            }
            else
            {
                list = list.Where(l => l.IsActive == false).ToList();
            }
            if (name != null)
            {
                list = list.Where(l => l.Name.Equals(name)).ToList();
            }
            return list;
        }

        public async Task<bool> ToggleCategoryAsync(int id)
        {
            var findCategory = await _context.Categories.FindAsync(id);
            if (findCategory==null)
            {
                return false;
            }
            findCategory.IsActive = !findCategory.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoriesDTO category)
        {
 
            Categories categories = new Categories()
            {
                CategoryId =id,
                Name = category.Name,
                Avatar = category.Avatar,
                CreatedDate = DateTime.Now,
                Description = category.Description,
                IsActive = category.IsActive,
                UpdatedDate = DateTime.Now,
            };
            _context.Categories.Entry(categories).State = EntityState.Modified;
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
