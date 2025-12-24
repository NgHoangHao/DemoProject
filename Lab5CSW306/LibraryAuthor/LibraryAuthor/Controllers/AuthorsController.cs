using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
       
    }
}
