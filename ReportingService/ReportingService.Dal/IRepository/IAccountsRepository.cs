using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository
{
    public interface IAccountsRepository
    {
        Task<List<AccountDto>> AccountsWithTransactionsResponseAsync(int countDays);
    }
}