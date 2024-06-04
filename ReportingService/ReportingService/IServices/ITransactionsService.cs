using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    public Task<List<TransactionResponse>> GetAllTransactionAsync();
    public  Task<List<TransactionResponse>> GetTransactionsByLeadIdAsync(Guid id);
    public  Task<List<TransactionWithAccountIdResponse>> GetTransactionsByAccountIdAsync(Guid id);

}
