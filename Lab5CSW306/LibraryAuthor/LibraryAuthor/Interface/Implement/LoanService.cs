using LibraryAuthor.DTO;
using LibraryAuthor.Model;
using Microsoft.EntityFrameworkCore;
namespace LibraryAuthor.Interface.Implement
{
    public class LoanService : ILoanService
    {
        private readonly LibraryContext _context;
        public LoanService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewLoanAsync(LoansDTO loan)
        {
            if (loan == null)
            {
                return false;
            }
            Loans loans = new Loans()
            {
                BookId = loan.BookId,
                DueDate = loan.DueDate,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate,
                Status = loan.Status,
                UserId = loan.UserId
            };
            var copyAmount = _context.Books.FirstOrDefault(b => b.BookId == loans.BookId).TotalCopies;
            if (copyAmount > 0)
            {
                await _context.Loans.AddAsync(loans);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Loans>> GetAllLoanAsync(int? UserId, int? status, DateTime? from, DateTime? to)
        {
            var list = await _context.Loans.ToListAsync();
            if (UserId != null)
            {
                list = list.Where(l => l.UserId == UserId).ToList();
            }
            if (status != null)
            {
                list = list.Where(l => l.Status == status).ToList();
            }
            if (from != null && to != null)
            {
                list = list.Where(l => l.LoanDate >= from && l.DueDate <= to).ToList();
            }
            return list;

        }

        public async Task<IEnumerable<BorrowBooksDTO>> GetBorrowBooksAsync(DateTime from, DateTime to, int max)
        {
            var result = await _context.Loans.Where(l => l.LoanDate >= from && l.DueDate <= to).GroupBy(l => new { l.BookId, l.Books.Title })
       .Select(g => new BorrowBooksDTO
       {
           BookId = g.Key.BookId,
           Title = g.Key.Title,
           BorrowedTime = g.Count()
       })
       .OrderByDescending(x => x.BorrowedTime)
       .Take(max)
       .ToListAsync();

            return result;
        }

        public async Task<Loans> GetLoanByIdAsync(int id)
        {
            var findLoan = await _context.Loans.FindAsync(id);
            return findLoan;
        }

        public async Task<bool> UpdateLoanAsync(int id, DateTime returnedDate)
        {
            var findLoan = await _context.Loans.FindAsync(id);
            if (findLoan == null)
            {
                return false;
            }
            findLoan.ReturnDate = returnedDate;
            findLoan.Status = 3;
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
