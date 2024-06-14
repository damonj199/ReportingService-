using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface IAccountsService
{
    Task<List<AccountForStatusUpdateResponse>> LeadsIdFromAccountsAsync(int countDays);
}
