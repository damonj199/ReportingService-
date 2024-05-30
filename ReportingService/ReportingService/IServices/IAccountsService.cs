using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface IAccountsService
{
    LeadDto GetAccountByLeadId(Guid Id);
}
