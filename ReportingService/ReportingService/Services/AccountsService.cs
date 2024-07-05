using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountRepository;
    private readonly ILogger _logger = Log.ForContext<AccountsService>();

    public AccountsService(IAccountsRepository accountsRepository)
    {
        _accountRepository = accountsRepository;
    }

    public async Task UpdateAccountAsync(AccountDto account)
    {
        _logger.Information("Берем данные и отдаем в репозиторий для обновления аккаунта");
        await _accountRepository.UpdateAccountAsync(account);
    }

    public async Task<Guid> AddAccountAsync(AccountDto account)
    {
        _logger.Information($"Account {account.Id}");
        await _accountRepository.AddAccountAsync(account);

        return account.Id;
    }
}
