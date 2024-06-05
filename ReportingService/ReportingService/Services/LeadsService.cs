using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _leadRepository;
    private readonly ILogger _logger = Log.ForContext<ReportsService>();
    private readonly IMapper _mapper;
    public LeadsService(ILeadsRepository leadRepository, IMapper mapper)
    {
        _leadRepository = leadRepository;
        _mapper = mapper;
    }

    public async Task<LeadResponse> GetLeadByIdAsync(Guid id)
    {
        _logger.Information("вызываем репозитория для поиска лида по id");
        var leadId = await _leadRepository.GetLeadByIdAsync(id);

        return _mapper.Map<LeadResponse>(leadId);
    }

    public async Task<List<LeadResponse>> GetAllInfoLeadsAsync(int countDays)
    {
        _logger.Information("Вызываем метод репозитория и передаем в него кооличесво дней для отчета");
        var leads = await _leadRepository.GetAllInfoLeadsAsync(countDays);

        return _mapper.Map<List<LeadResponse>>(leads);
    }
}
