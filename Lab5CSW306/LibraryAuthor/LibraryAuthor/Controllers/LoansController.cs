using LibraryAuthor.DTO;
using LibraryAuthor.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }
        [HttpGet]
        [Authorize(Policy = "MinimumMembership")]
        public async Task<ActionResult> GetAllLoan([FromQuery] int? id , [FromQuery] int? status, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result= await _loanService.GetAllLoanAsync(id, status, from, to);
            return Ok(result);
        }
        
        [HttpGet("top-borrowed")]
        [Authorize(Policy = "AdminOrLibrarian")]
        public async Task<ActionResult> GetMaxBorrowBooks([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int max)
        {
            var result = await _loanService.GetBorrowBooksAsync(from, to, max);
            return Ok(result);
        }
    }
}
