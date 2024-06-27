using MassTransit;
using ReportingService.Api.Consumer;
using ReportingService.Core.Models.Responses;

namespace ReportingService.Api.Configure;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureDB(configurationManager);
        services.AddAutoMapper(typeof(MappingResponseProfile));
        services.AddControllersWithViews()
        .AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

        services.AddMassTransit(x =>
        {
            x.AddConsumer<TransactionsConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("TransactionCreated", e =>
                {
                    e.ConfigureConsumer<TransactionsConsumer>(context);
                });
            });
        });
        //services.AddSingleton<>();
    }
}
