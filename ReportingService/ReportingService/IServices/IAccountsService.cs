using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface IAccountsService
{
    Task<List<AccountForStatusUpdateResponse>> AccountsWithTransactionsResponseAsync(int countDays);
}
