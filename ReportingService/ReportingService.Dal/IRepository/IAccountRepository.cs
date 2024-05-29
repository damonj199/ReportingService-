using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface IAccountRepository
{
    AccountDto GetAccountByLeadId(Guid leadid);
}
