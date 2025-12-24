using LibraryAuthor.DTO;
using LibraryAuthor.Model;

namespace LibraryAuthor.Interface
{
    public interface ILoanService
    {
        Task<IEnumerable<Loans>> GetAllLoanAsync(int? UserId, int? status, DateTime? from, DateTime? to);
        Task<Loans> GetLoanByIdAsync(int id);
        Task<bool> AddNewLoanAsync(LoansDTO loan);
        Task<bool> UpdateLoanAsync(int id, DateTime returnedDate);
        Task <IEnumerable<BorrowBooksDTO>> GetBorrowBooksAsync(DateTime from, DateTime to, int max);
    }
}
