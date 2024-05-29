using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface IAccountsService
{
    AccountDto GetAccountByLeadId(Guid leadId);
}
