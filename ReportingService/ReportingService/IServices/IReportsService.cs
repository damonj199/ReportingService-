using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface IReportsService
{
    ReportDto GetReportById(Guid id);
}
