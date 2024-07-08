using AutoMapper;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;
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
        _logger.Information("Let's go -> repository to look for leads full informations by id");
        var leadId = await _leadRepository.GetLeadFullInfoByIdAsync(id);

        return _mapper.Map<LeadResponse>(leadId);
    }

    public async Task<List<LeadsBirthDateResponse>> GetLeadsWithBirthdayAsync(int periodBdate)
    {
        _logger.Information("Let's go -> repository, to look for leads who have a birthday");
        var leadsBdate = await _leadRepository.GetLeadsWithBirthdayAsync(periodBdate);

        return _mapper.Map<List<LeadsBirthDateResponse>>(leadsBdate);
    }

    public async Task<LeadDto> AddLeadAsync(LeadDto lead)
    {
        _logger.Information("Add new Lead -> repository");
        await _leadRepository.AddLeadAsync(lead);
        return lead;
    }

    public async Task UpdateLeadAsync(LeadDto lead)
    {
        _logger.Information("Send the data to Repository for updated lead");
        await _leadRepository.UpdateLeadAsync(lead);
    }

    public async Task DeletedLeadAsync(LeadDto lead)
    {
        _logger.Information("Send the data to Repository for deleted lead");
        await _leadRepository.DeleteLeadAsync(lead);
    }
}
