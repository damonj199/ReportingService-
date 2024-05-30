using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface IAccountRepository
{
    LeadDto GetAccountByLeadId(Guid id);
}
