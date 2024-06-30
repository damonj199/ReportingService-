using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReportingService.Core.Enums;
using ReportingService.Dal;

namespace ReportingService.Api.Configure;

public static class DataBaseExtansions
{
    public static void ConfigureDB(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<ReportingServiceContext>(
            options => options
                .UseNpgsql(configurationManager
                .GetConnectionString("ReportingService"))
                .UseSnakeCaseNamingConvention());

        NpgsqlConnection.GlobalTypeMapper.MapEnum<Currency>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<TransactionType>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<AccountStatus>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<LeadStatus>();

    }
}
