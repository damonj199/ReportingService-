using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface ILeadsRepository
{
    Task<LeadDto> GetLeadFullInfoByIdAsync(Guid id);
    Task<List<LeadDto>> GetLeadsWithBirthdayAsync(int periodBdate);
    //Task<List<LeadDto>> LeadWithTransactionsResponseAsync(int countDays);
}
