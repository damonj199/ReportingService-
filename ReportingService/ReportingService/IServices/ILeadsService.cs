using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    LeadResponse GetLeadById(Guid Id);
    List<LeadResponse> GetLeads();
}
