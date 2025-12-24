using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
       private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Authorize(Policy = "VerifiedEmailOnly")]
        public async Task<ActionResult> GetAllBook()
        {
            var list= await _bookService.GetAllBookAsync();
            return Ok(list);
        }
    }
}
