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

    public async Task<List<LeadsBirthDateResponse>> GetLeadsWithBirthdayAsync(int periodBdate)
    {
        _logger.Information("Идем в репозиторий искать лидов у кого др");
        var leadsBdate = await _leadRepository.GetLeadsWithBirthdayAsync(periodBdate);

        return _mapper.Map<List<LeadsBirthDateResponse>>(leadsBdate);
    }
}
