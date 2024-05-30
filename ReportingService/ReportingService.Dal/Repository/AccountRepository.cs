using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class AccountRepository: BaseRepository, IAccountRepository
{
    public AccountRepository(ReportingServiceContext context): base(context)
    {
        
    }

    public LeadDto GetAccountByLeadId(Guid Id)
    {
        return _cxt.Leads.Include(x => x.Accounts).FirstOrDefault(a => a.Id == Id);
        //return new AccountDto();
    }
}
