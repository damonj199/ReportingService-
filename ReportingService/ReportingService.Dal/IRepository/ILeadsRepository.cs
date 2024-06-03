using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ILeadsRepository
{
    Task<LeadDto> GetLeadByIdAsync(Guid id);
    Task<List<LeadDto>> GetLeadsAsync();
}
