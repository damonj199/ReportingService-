using Serilog;
using ReportingService.Bll.IServices;
using ReportingService.Dal.IRepository;
using AutoMapper;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.Services;

public class ReportServices: IReportServices
{
    private readonly IReportRepository _reportRepository;
    private readonly ILogger _logger = Log.ForContext<ReportServices>();
    private readonly IMapper _mapper;

    public ReportServices(IReportRepository reportRepository, IMapper mapper)
    {
        _mapper = mapper;
        _reportRepository = reportRepository;
    }

    public ReportDto GetReportById(Guid id)
    {
        return _reportRepository.GetReportById(id);
    }
}
