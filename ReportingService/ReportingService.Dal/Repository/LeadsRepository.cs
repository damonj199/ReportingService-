using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class LeadsRepository: BaseRepository, ILeadsRepository
{
    public LeadsRepository(ReportingServiceContext context): base(context)
    {
        
    }

    public LeadDto GetLeadById(Guid Id)
    {
        return _cxt.Leads.FirstOrDefault(a => a.Id == Id);
        //return new AccountDto();
    }

    public List<LeadDto> GetLeads()
    {
        return _cxt.Leads.ToList();
    }
}
