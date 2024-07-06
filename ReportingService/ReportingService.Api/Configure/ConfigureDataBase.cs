using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReportingService.Core.Enums;
using ReportingService.Dal;

namespace ReportingService.Api.Configure;

public static class DataBaseExtansions
{
    public static void ConfigureDB(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[ConfigurationSettings.DatabaseSettings];

        services.AddDbContext<ReportingServiceContext>(
            options => options
                .UseNpgsql(configuration
                .GetConnectionString("ReportingService"))
                .UseSnakeCaseNamingConvention());

        NpgsqlConnection.GlobalTypeMapper.MapEnum<Currency>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<TransactionType>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<AccountStatus>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<LeadStatus>();

    }
}
