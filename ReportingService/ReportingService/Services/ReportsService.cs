using Serilog;
using ReportingService.Bll.IServices;
using ReportingService.Dal.IRepository;
using AutoMapper;
using ReportingService.Core.Dtos;

namespace ReportingService.Bll.Services;

public class ReportsService: IReportsService
{
    private readonly IReportRepository _reportRepository;
    private readonly ILogger _logger = Log.ForContext<ReportsService>();
    private readonly IMapper _mapper;

    public ReportsService(IReportRepository reportRepository, IMapper mapper)
    {
        _mapper = mapper;
        _reportRepository = reportRepository;
    }

    public ReportDto GetReportById(Guid id)
    {
        return _reportRepository.GetReportById(id);
    }
}
