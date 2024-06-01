using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _accountRepository;
    private readonly ILogger _logger = Log.ForContext<ReportsService>();
    private readonly IMapper _mapper;
    public LeadsService(ILeadsRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    //List<Guid> AccountsId = new List<Guid>();

    public LeadResponse GetLeadById(Guid Id)
    {
        _logger.Information("проверяем работает ли сервис слой");
        return _mapper.Map<LeadResponse>(_accountRepository.GetLeadById(Id));
    }

    public List<LeadResponse> GetLeads()
    {
        _logger.Information("Что пока не работает!");
        return _mapper.Map<List<LeadResponse>>(_accountRepository.GetLeads());
    }
}
