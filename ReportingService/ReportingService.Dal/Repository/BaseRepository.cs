namespace ReportingService.Dal.Repository;

public class BaseRepository
{
    protected readonly ReportingServiceContext _cxt;
    public BaseRepository(ReportingServiceContext context)
    {
        _cxt = context;
    }
}
