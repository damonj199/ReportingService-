namespace ReportingService.Dal.Repository;

public class BaseRepository
{
    protected readonly ReportingServiceContext _cxt;
    public BaseRepository(ReportingServiceContext connectionString)
    {
        _cxt = connectionString;
    }
}
