using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class LeadsRepository: BaseRepository, ILeadsRepository
{
    public LeadsRepository(ReportingServiceContext context): base(context)
    {
        
    }

    public async Task<LeadDto> GetLeadFullInfoByIdAsync(Guid id)
    {
        var leadId = await _cxt.Leads
            .AsNoTracking()
            .Include(a => a.Accounts)
            .ThenInclude(at => at.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        return leadId;
    }

    public async Task<List<LeadDto>> LeadWithTransactionsResponseAsync(int countDays)
    {
        DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

        var leads = await _cxt.Leads
            .AsNoTracking()
            .Include(a => a.Accounts)
            .ThenInclude(at => at.Transactions.Where(t => t.Date >= startDate))
            .ToListAsync();
        return leads;
    }

    public async Task<List<LeadDto>> GetLeadsWithBirthdayTodayAsync()
    {
        DateTime today = DateTime.Today;
        
        var leads = await _cxt.Leads
            .AsNoTracking()
            .Where(l => l.BirthDate.Month == today.Month && l.BirthDate.Day == today.Day)
            .ToListAsync();

        return leads;
    }
}
