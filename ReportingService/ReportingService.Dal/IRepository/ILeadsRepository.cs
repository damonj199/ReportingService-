using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ILeadsRepository
{
    Task<Guid> AddLeadAsync(LeadDto lead);
    Task DeleteLeadAsync(LeadDto lead);
    //Task<LeadDto> GetLeadByIdAsync(Guid id);
    Task<LeadDto> GetLeadFullInfoByIdAsync(Guid id);
    Task<List<LeadDto>> GetLeadsWithBirthdayAsync(int periodBdate);
    Task UpdateLeadAsync(LeadDto leadDto);
}
