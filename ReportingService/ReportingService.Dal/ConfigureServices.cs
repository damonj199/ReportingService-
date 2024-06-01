using Microsoft.Extensions.DependencyInjection;
using ReportingService.Dal.IRepository;
using ReportingService.Dal.Repository;
namespace ReportingService.Dal;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadsRepository, LeadsRepository>();
        //services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<ITransactiontRepository, TransactiontRepository>();
    }
}
