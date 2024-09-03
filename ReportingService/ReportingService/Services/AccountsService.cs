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
        _logger.Information("We take the data and send it to the repository to update the account");
        await _accountRepository.UpdateAccountAsync(account);
    }

    public async Task<Guid> AddAccountAsync(AccountDto account)
    {
        _logger.Information($"New Account created service -> Repository {account.Id}");
        await _accountRepository.AddAccountAsync(account);

        return account.Id;
    }
}
