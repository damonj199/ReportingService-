using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Dal.IRepository;
using Serilog;

namespace ReportingService.Bll.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _leadRepository;
    private readonly ILogger _logger = Log.ForContext<LeadsService>();
    private readonly IMapper _mapper;
    public LeadsService(ILeadsRepository leadRepository, IMapper mapper)
    {
        _leadRepository = leadRepository;
        _mapper = mapper;
    }

    public async Task<LeadResponse> GetLeadFullInfoByIdAsync(Guid id)
    {
        _logger.Information("вызываем репозитория для поиска лида по id");
        var leadId = await _leadRepository.GetLeadFullInfoByIdAsync(id);

        return _mapper.Map<LeadResponse>(leadId);
    }

    public async Task<List<LeadForStatusUpdateResponse>> LeadWithTransactionsResponseAsync(int countDays)
    {
        if (countDays <= 0)
        {
            _logger.Information("не допустимое значение дней для отчета!");
            return null;
        }
        else
        {
            _logger.Information("Вызываем метод репозитория и передаем в него кооличесво дней для отчета");
            var leads = await _leadRepository.LeadWithTransactionsResponseAsync(countDays);

            return _mapper.Map<List<LeadForStatusUpdateResponse>>(leads);
        }
    }
}
