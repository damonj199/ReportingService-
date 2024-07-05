using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface IAccountsService
{
    Task<Guid> AddAccountAsync(AccountDto account);
    Task UpdateAccountAsync(AccountDto account);
}
