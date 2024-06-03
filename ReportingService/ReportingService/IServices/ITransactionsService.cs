using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    public Task<List<TransactionResponse>> GetAllTransactionAsync();
    public  Task<List<TransactionResponse>> GetTransactionsByLeadIdAsynk(Guid id);
    public  Task<List<TransactionWithAccountIdResponse>> GetTransactionsByAccountIdAsynk(Guid id);

}
