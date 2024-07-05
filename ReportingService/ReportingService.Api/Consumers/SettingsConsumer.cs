using MassTransit;
using Messaging.Shared;
using Serilog;
using System.Text.Json;

namespace ReportingService.Api.Consumers;

public class SettingsConsumer : IConsumer<ConfigurationMessage>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<SettingsConsumer>();

    public async Task Consume(ConsumeContext<ConfigurationMessage> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message.Configurations);

            _logger.Information($"Configuration message: {jsonMessage} for Reporting_Service");

    }
};