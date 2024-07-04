using ReportingService.Core.Dtos;

namespace ReportingService.Dal.IRepository;

public interface IAccountsRepository
{
    public Task UpdateAccountAsync(AccountDto account);
    public Task<Guid> AddAccountAsync(AccountDto account);
}
