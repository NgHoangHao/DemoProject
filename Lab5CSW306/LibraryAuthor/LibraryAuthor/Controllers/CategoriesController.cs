using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
       
    }
}
