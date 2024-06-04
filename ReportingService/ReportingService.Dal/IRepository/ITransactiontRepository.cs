using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository
{
    public interface ITransactiontRepository
    {
        public Task<List<TransactionDto>> GetAllTransactionAsync();
        public  Task<List<TransactionDto>> GetTransactionsByLeadIdAsync(Guid id);
        public  Task<List<TransactionDto>> GetTransactionsByAccountIdAsync(Guid id);

    }
}
