using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    Task<LeadDto> AddLeadAsync(LeadDto lead);
    Task DeletedLeadAsync(LeadDto lead);
    Task<LeadResponse> GetLeadFullInfoByIdAsync(Guid Id);
    Task<List<LeadsBirthDateResponse>> GetLeadsWithBirthdayAsync(int periodBdate);
    Task UpdateLeadAsync(LeadDto lead);
}
