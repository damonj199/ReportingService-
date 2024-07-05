using MassTransit;
using ReportingService.Api.Consumer;
using ReportingService.Api.Consumers;
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
            x.AddConsumer<LeadUpdatedConsumer>();
            x.AddConsumer<LeadStatusUpdatedConsumer>();
            x.AddConsumer<LeadDeletedConsumer>();
            x.AddConsumer<LeadCreatedConsumer>();
            x.AddConsumer<LeadBirthDateUpdatedConsumer>();
            x.AddConsumer<AccountCreatedConsumer>();
            x.AddConsumer<AccountBlockedConsumer>();
            x.AddConsumer<AccountUpdatedStatusConsumer>();
            x.AddConsumer<SettingsConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("settings_queue", e =>
                {
                    e.Bind("configurations-exchange", x =>
                    {
                        x.ExchangeType = "fanout";
                    });
                    e.ConfigureConsumer<SettingsConsumer>(context);
                });

                cfg.ReceiveEndpoint("TransactionCreated", e =>
                {
                    e.ConfigureConsumer<TransactionsConsumer>(context);
                });

                cfg.ReceiveEndpoint("LeadUpdated", e =>
                {
                    e.ConfigureConsumer<LeadUpdatedConsumer>(context);
                });

                cfg.ReceiveEndpoint("LeadStatusUpdated", e =>
                {
                    e.ConfigureConsumer<LeadStatusUpdatedConsumer>(context);
                });

                cfg.ReceiveEndpoint("LeadDeleted", e =>
                {
                    e.ConfigureConsumer<LeadDeletedConsumer>(context);
                });

                cfg.ReceiveEndpoint("LeadCreated", e =>
                {
                    e.ConfigureConsumer<LeadCreatedConsumer>(context);
                });

                cfg.ReceiveEndpoint("LeadBirthDateUpdated", e =>
                {
                    e.ConfigureConsumer<LeadBirthDateUpdatedConsumer>(context);
                });

                cfg.ReceiveEndpoint("AccountUpdatedStatus", e =>
                {
                    e.ConfigureConsumer<AccountUpdatedStatusConsumer>(context);
                });

                cfg.ReceiveEndpoint("AccountBlocked", e =>
                {
                    e.ConfigureConsumer<AccountBlockedConsumer>(context);
                });

                cfg.ReceiveEndpoint("AccountCreated", e =>
                {
                    e.ConfigureConsumer<AccountCreatedConsumer>(context);
                });
            });
        });
    }
}
