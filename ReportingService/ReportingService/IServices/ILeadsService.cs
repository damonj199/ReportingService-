using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    Task<LeadResponse> GetLeadFullInfoByIdAsync(Guid Id);
    Task<List<LeadForStatusUpdateResponse>> LeadWithTransactionsResponseAsync(int countDays);
}
