using ReportingService.Core.Dtos;

namespace ReportingService.Bll.Services;

public class AccountsService
{
    public AccountsService()
    {
    }

    List<Guid> AccountsId = new List<Guid>();

    public AccountDto GetAccountByLeadId(Guid leadId)
    {
        return new AccountDto();
    }
}
