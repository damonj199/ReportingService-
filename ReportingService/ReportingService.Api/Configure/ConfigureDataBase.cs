using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReportingService.Core.Enums;
using ReportingService.Dal;

namespace ReportingService.Api.Configure;

public static class DataBaseExtansions
{
    public static void ConfigureDB(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:ReportingService"];

        var dataSourceBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        var dataSource = dataSourceBuilder.ConnectionString;

        services.AddDbContext<ReportingServiceContext>(
            options => options
                .UseNpgsql(dataSource)
                .UseSnakeCaseNamingConvention());

        NpgsqlConnection.GlobalTypeMapper.MapEnum<Currency>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<TransactionType>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<AccountStatus>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<LeadStatus>();

    }
}
