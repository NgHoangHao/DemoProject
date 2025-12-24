using LibraryAuthor.DTO;
using LibraryAuthor.Model;

namespace LibraryAuthor.Interface
{
    public interface ICarouselService
    {
        Task<IEnumerable<Carousel>> GetAllCarouselAsync();
        Task<Carousel> GetCarouselByIdAsync(int id);
        Task<bool> AddNewCarouselAsync(CarouselDTO Carousel);
        Task<bool> UpdateCarouselById(int id, CarouselDTO Carousel);
        Task<bool> DeleteCarouselByIdAsync(int id);
    }
}
