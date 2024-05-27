using ReportingService.Core.Dtos;

namespace ReportingService.Bll.IServices;

public interface IReportServices
{
    ReportDto GetReportById(Guid id);
}
