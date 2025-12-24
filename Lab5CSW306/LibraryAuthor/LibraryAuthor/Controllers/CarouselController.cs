
using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : Controller
    {
        private ICarouselService _carouselService;
        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        
    }
}
