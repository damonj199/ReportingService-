using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    Task<LeadResponse> GetLeadByIdAsync(Guid Id);
    Task<List<LeadForStatusUpdateResponse>> GetAllInfoLeadsAsync(int countDays);
}
