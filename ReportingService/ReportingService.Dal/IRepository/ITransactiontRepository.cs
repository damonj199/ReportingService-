using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ITransactiontRepository
{
    Task<TransactionDto> GetTransactionByIdAsync(Guid id);
    Task<List<AccountNegativBalanceDto>> GetAccountsWithNegativeBalanceAsync();
    Task<List<TransactionDto>> GetTransactionsByPeriodDayAsync(int countDays);
    Task<TransactionDto> AddTransactionsAsync(TransactionDto transaction);
}
