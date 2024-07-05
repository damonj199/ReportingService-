using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Dal.Repository;

public class AccountsRepository : BaseRepository, IAccountsRepository
{
    private readonly ILogger _logger = Log.ForContext<LeadsRepository>();
    public AccountsRepository(ReportingServiceContext context) : base(context)
    {
    }

    public async Task<Guid> AddAccountAsync(AccountDto account)
    {
        await _cxt.Accounts.AddAsync(account);
        await _cxt.SaveChangesAsync();

        _logger.Information("Добавили новый аккаунт");

        return account.Id;
    }

    public async Task UpdateAccountAsync(AccountDto account)
    {
        _cxt.Accounts.Update(account);
        await _cxt.SaveChangesAsync();

        _logger.Information("Информация о аккаунте обновлена");
    }

    //public async Task BlockedAccount(AccountDto account)
    //{
    //    await _cxt.Accounts.ExecuteUpdate(s => s.SetProperty(d => d.Status, d => AccountStatus.Blocked));
    //    await _cxt.SaveChangesAsync();
    //    _logger.Information("");
    //}
}
