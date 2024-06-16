using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountRepository;
    private readonly ILogger _logger = Log.ForContext<AccountsService>();
    private readonly IMapper _mapper;

    public AccountsService(IAccountsRepository AccountRepository, IMapper mapper)
    {
        _accountRepository = AccountRepository;
        _mapper = mapper;
    }

    public async Task<List<AccountForStatusUpdateResponse>> LeadsIdFromAccountsAsync(int countDays)
    {
        if (countDays <= 0)
        {
            _logger.Information("не допустимое значение дней для отчета!");
            return null;
        }
        else
        {
            _logger.Information("Вызываем метод репозитория и передаем в него кооличесво дней для отчета");
            var leads = await _accountRepository.LeadsIdFromAccountsAsync(countDays);

            return _mapper.Map<List<AccountForStatusUpdateResponse>>(leads);
        }
    }

}
