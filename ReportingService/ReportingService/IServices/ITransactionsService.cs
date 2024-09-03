using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface ITransactionsService
{
    Task<TransactionResponse> GetTransactionByIdsAsync(Guid id);
    Task<List<NegativBalanceResponse>> GetAccountsNegativBalanceAsync();
    Task<List<TransactionResponse>> GetTransactionsByPeriodDayAsync(int countDays);
    Task<TransactionDto> AddTransactionsAsync(TransactionDto transaction);
}
