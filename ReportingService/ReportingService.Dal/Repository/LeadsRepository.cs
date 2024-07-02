using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Dal.Repository;

public class LeadsRepository : BaseRepository, ILeadsRepository
{
    private readonly ILogger _logger = Log.ForContext<LeadsRepository>();
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

        _logger.Information("Достали все данные по лиду из базы");

        return leadId;
    }

    //public async Task<LeadDto> GetLeadByIdAsync(Guid id)
    //{
    //    _logger.Information("Ищем лида по id");
    //    return await _cxt.Leads.FirstOrDefaultAsync(a => a.Id == id);
    //}

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

    public async Task UpdateLeadAsync(LeadDto leadDto)
    {
        _cxt.Leads.Update(leadDto);
        await _cxt.SaveChangesAsync();
        _logger.Information($"Данные пользователя {leadDto.Id} обновлены");
    }

    public async Task<Guid> AddLeadAsync(LeadDto lead)
    {
        await _cxt.Leads.AddAsync(lead);
        await _cxt.SaveChangesAsync();

        _logger.Information($"Добавлен новый пользователь {lead.Name}");

        return lead.Id;
    }

    public async Task DeleteLeadAsync(LeadDto lead)
    {
        _cxt.Leads.Remove(lead);
        await _cxt.SaveChangesAsync();

        _logger.Information("Пользователь удален успешно!");
    }
}
