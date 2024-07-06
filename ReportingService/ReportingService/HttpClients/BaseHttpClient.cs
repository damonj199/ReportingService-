namespace ReportingService.Bll.HttpClients;

public class BaseHttpClient : HttpClient
{
    public HttpClient Client { get; }

    protected BaseHttpClient(HttpClient client)
    {
        Client = client;
        Client.Timeout = new TimeSpan(HttpClientSettings.HttpClientTimeoutHour, HttpClientSettings.HttpClientTimeoutMin, HttpClientSettings.HttpClientTimeoutSec);
        Client.DefaultRequestHeaders.Clear();
    }
}
