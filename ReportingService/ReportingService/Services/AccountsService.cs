using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class AccountsService: IAccountsService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger _logger = Log.ForContext<ReportsService>();
    private readonly IMapper _mapper;
    public AccountsService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    //List<Guid> AccountsId = new List<Guid>();

    public LeadDto GetAccountByLeadId(Guid Id)
    {
        return _accountRepository.GetAccountByLeadId(Id);
    }
}
