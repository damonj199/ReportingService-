namespace ReportingService.Bll.IServices;

public interface IHttpClientService
{
    Task<T> Get<T>(string urlForRequest, CancellationToken cancellationToken);
}
