using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class LeadsRepository: BaseRepository, ILeadsRepository
{
    public LeadsRepository(ReportingServiceContext context): base(context)
    {
        
    }

    public async Task<LeadDto> GetLeadByIdAsync(Guid Id)
    {
        var leadId = await _cxt.Leads.FirstOrDefaultAsync(a => a.Id == Id);
        return leadId;
    }

    public async Task<List<LeadDto>> GetLeadsAsync()
    {
        var leads = await _cxt.Leads.ToListAsync();
        return leads;
    }
}
