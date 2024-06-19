using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    Task<List<TransactionResponse>> GetAllTransactionsAsync();
    Task<List<TransactionResponse>> GetTransactionsByLeadIdAsync(Guid id);
    Task<List<TransactionWithAccountIdResponse>> GetTransactionsByAccountIdAsync(Guid id);
    Task<List<NegativBalanceResponse>> GetAccountsNegativBalanceAsync();
    Task<List<LeadForStatusUpdateResponse>> LeadWithTransactionsResponseAsync(int countDays);
}
