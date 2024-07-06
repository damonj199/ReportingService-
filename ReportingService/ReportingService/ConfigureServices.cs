using Microsoft.Extensions.DependencyInjection;
using ReportingService.Bll.HttpClients;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Services;
namespace ReportingService.Bll;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<ILeadsService, LeadsService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        services.AddTransient<IHttpClientService, HttpClientService>();
    }
}
