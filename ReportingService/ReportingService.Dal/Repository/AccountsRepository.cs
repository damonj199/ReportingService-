using Microsoft.EntityFrameworkCore;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;

namespace ReportingService.Dal.Repository;

public class AccountsRepository : BaseRepository, IAccountsRepository
{
    public AccountsRepository(ReportingServiceContext context) : base(context)
    {
    }

    public async Task<List<AccountDto>> AccountsWithTransactionsResponseAsync(int countDays)
    {
        DateTime startDate = DateTime.UtcNow.AddDays(-countDays);

        var accounts = await _cxt.Accounts
            .AsNoTracking()
            .Include(t => t.Transactions.Where(t => t.Date >= startDate))
            .ToListAsync();

        return accounts;
    }

}
