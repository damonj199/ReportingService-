﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<List<LeadDto>> LeadWithTransactionsResponseAsync(int countDays)
    {
        DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

        var leads = await _cxt.Leads
            .AsNoTracking()
            .Include(a => a.Accounts)
            .ThenInclude(at => at.Transactions)
            .Where(l => l.Accounts.Any(a => a.Transactions.Any(t => t.Date >= startDate)))
            .Select(l => new LeadDto
            {
                Id = l.Id,
                Name = l.Name,
                Status = l.Status,
                BirthDate = l.BirthDate,
                Accounts = l.Accounts.Select(a => new AccountDto
                {
                    Id = a.Id,
                    Transactions = a.Transactions
                     .Where(t => t.Date >= startDate)
                     .Select(t => new TransactionDto
                     {
                         Id = t.Id,
                         TransactionType = t.TransactionType,
                         Amount = t.Amount,
                         Date = t.Date
                     }).ToList()
                }).ToList()
            })
               .Take(1000)
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
