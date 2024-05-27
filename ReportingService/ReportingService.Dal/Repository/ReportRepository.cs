using ReportingService.Core.Dtos;

namespace ReportingService.Dal.Repository;

public class ReportRepository : BaseRepository
{
    public ReportRepository(ReportingServiceContext context) : base(context)
    {
    }

    public ReportDto GetReportById(Guid id)
    {
        return _cxt
    }
}
