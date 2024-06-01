using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ILeadsRepository
{
    LeadDto GetLeadById(Guid id);
    List<LeadDto> GetLeads();
}
