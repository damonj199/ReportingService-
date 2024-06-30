using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadStatusUpdatedConsumer : IConsumer<LeadStatusUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadStatusUpdatedConsumer>();

    public LeadStatusUpdatedConsumer(ILogger<LeadStatusUpdatedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<LeadStatusUpdated> context)
    {
        _logger.Information("Received message: update status {Text}", context.Message.Status);

        await Task.CompletedTask;
    }
}
