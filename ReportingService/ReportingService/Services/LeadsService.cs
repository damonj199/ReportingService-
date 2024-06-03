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

    public async Task<LeadResponse> GetLeadByIdAsync(Guid Id)
    {
        _logger.Information("проверяем работает ли сервис слой");
        var leadId = await _accountRepository.GetLeadByIdAsync(Id);

        return _mapper.Map<LeadResponse>(leadId);
    }

    public async Task<List<LeadResponse>> GetLeadsAsync()
    {
        _logger.Information("Что пока не работает!");
        var leads = await _accountRepository.GetLeadsAsync();

        return _mapper.Map<List<LeadResponse>>(leads);
    }
}
