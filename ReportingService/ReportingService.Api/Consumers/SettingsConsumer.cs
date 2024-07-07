using MassTransit;
using Messaging.Shared;
using ReportingService.Api.Configure.Exceptions;
using Serilog;
using System.Text.Json;

namespace ReportingService.Api.Consumers;

public class SettingsConsumer(IConfiguration configuration) : IConsumer<ConfigurationMessage>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<SettingsConsumer>();

    public Task Consume(ConsumeContext<ConfigurationMessage> context)
    {
        if(context.Message.ServiceType != Core.Enums.ServiceType.reportingService)
        {
            return Task.CompletedTask;
        }

        var jsonMessage = JsonSerializer.Serialize(context.Message.Configurations);

        _logger.Information($"Configuration message: {jsonMessage} for Reporting_Service");

        configuration.UpdateSettingsFromConfigurationManager(context.Message.Configurations);

        return Task.CompletedTask;
    }
};