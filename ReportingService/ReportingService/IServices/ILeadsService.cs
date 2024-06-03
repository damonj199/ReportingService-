using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    Task<LeadResponse> GetLeadByIdAsync(Guid Id);
    Task<List<LeadResponse>> GetLeadsAsync();
}
