using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository
{
    public interface ITransactiontRepository
    {
        public Task<List<TransactionDto>> GetAllTransactionAsync();
        public  Task<List<TransactionDto>> GetTransactionsByLeadIdAsynk(Guid id);
        public  Task<List<TransactionDto>> GetTransactionsByAccountIdAsynk(Guid id);

    }
}
