using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class LeadsRepository : BaseRepository, ILeadsRepository
{
    public LeadsRepository(ReportingServiceContext context) : base(context)
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

    public async Task<List<LeadDto>> GetLeadsWithBirthdayAsync(int periodBdate)
    {
        DateTime toDay = DateTime.Today;
        DateTime startDay = DateTime.Today.AddDays(-periodBdate);

        IQueryable<LeadDto> leads;

        leads = startDay.Month != toDay.Month ?
            _cxt.Leads
                .AsNoTracking()
                .Where(l => l.Month == startDay.Month && l.Day > startDay.Day || l.Month == toDay.Month && l.Day <= toDay.Day) :
            _cxt.Leads
                .AsNoTracking()
                .Where(l => l.Month == startDay.Month && l.Day > startDay.Day && l.Month == toDay.Month && l.Day <= toDay.Day);

        return await leads.ToListAsync();
    }

}
