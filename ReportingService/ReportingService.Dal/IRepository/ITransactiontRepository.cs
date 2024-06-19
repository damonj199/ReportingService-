using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ITransactiontRepository
{
    Task<List<TransactionDto>> GetAllTransactionsAsync();
    Task<List<TransactionDto>> GetTransactionsByLeadIdAsync(Guid id);
    Task<List<TransactionDto>> GetTransactionsByAccountIdAsync(Guid id);
    Task<List<AccountNegativBalanceDto>> GetAccountsWithNegativeBalanceAsync();
    Task<List<TransactionDto>> LeadWithTransactionsResponseAsync(int countDays);
}
