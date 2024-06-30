using Microsoft.Extensions.DependencyInjection;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Services;
namespace ReportingService.Bll;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadsService, LeadsService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
    }
}
