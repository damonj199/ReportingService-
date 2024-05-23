using Microsoft.EntityFrameworkCore;
using ReportingService.Dal;

namespace ReportingService.Api.Configure;

public static class DataBaseExtansions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<ReportingServiceContext>(
            options => options
                .UseNpgsql(configurationManager
                .GetConnectionString("ReportingService"))
                .UseSnakeCaseNamingConvention());
    }
}
