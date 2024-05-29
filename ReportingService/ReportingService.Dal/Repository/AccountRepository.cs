using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;

namespace ReportingService.Dal.Repository;

public class AccountRepository: BaseRepository
{
    public AccountRepository(ReportingServiceContext context): base(context)
    {
        
    }

    public AccountDto GetAccountByLeadId(Guid leadId)
    {
        return _cxt.Leads.Include(x => x.Accounts).FirstOrDefault(a => a.Id == id);
    }
}
