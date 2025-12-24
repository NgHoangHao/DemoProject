using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthor.Interface.Implement
{
    public class CarouselService : ICarouselService
    {
        private readonly LibraryContext _context;
        private readonly IWebHostEnvironment _env;
        public CarouselService(LibraryContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<bool> AddNewCarouselAsync(CarouselDTO carousel)
        {
            if (carousel == null)
            {
                return false;
            }
            var Carousel = new Carousel()
            {
                CreatedDate= carousel.CreatedDate,
                Description= carousel.Description,
                ImageUrl=carousel.ImageUrl,
                IsActive = carousel.IsActive,
                LinkUrl = carousel.LinkUrl,
                Order = carousel.Order,
                Title= carousel.Title,
                UpdatedDate= carousel.UpdatedDate
            };
            await _context.Carousel.AddAsync(Carousel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCarouselByIdAsync(int id)
        {
            var findCarousel = await _context.Carousel.FindAsync(id);
            if (findCarousel != null)
            {
                if (findCarousel.ImageUrl != null)
                {
                    var relativePath = findCarousel.ImageUrl.TrimStart('/');
                    var imagePath = Path.Combine(_env.WebRootPath, relativePath);

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                _context.Carousel.Remove(findCarousel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Carousel>> GetAllCarouselAsync()
        {
            var carouselList = await _context.Carousel.Where(p => p.IsActive == true).ToListAsync();
            return carouselList;
        }

        public async Task<Carousel> GetCarouselByIdAsync(int id)
        {
            var findCarousel = await _context.Carousel.FindAsync(id);
            return findCarousel;
        }

        public async Task<bool> UpdateCarouselById(int id, CarouselDTO carousel)
        {
            var find = new Carousel()
            {
                CarouselId = id,
                CreatedDate= carousel.CreatedDate,
                Description= carousel.Description,
                ImageUrl =carousel.ImageUrl,
                Order= carousel.Order,
                LinkUrl= carousel.LinkUrl,
                Title= carousel.Title,
                UpdatedDate =carousel.UpdatedDate,
                IsActive = true

            };
            _context.Entry(find).State = EntityState.Modified;
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
