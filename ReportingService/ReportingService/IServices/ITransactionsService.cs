using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    Task<TransactionResponse> GetTransactionByIdsAsync(Guid id);
    Task<List<NegativBalanceResponse>> GetAccountsNegativBalanceAsync();
    Task<List<TransactionResponse>> GetTransactionsByPeriodDayAsync(int countDays);
}
