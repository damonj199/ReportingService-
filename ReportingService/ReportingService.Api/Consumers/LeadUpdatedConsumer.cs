using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadUpdatedConsumer : IConsumer<LeadUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadStatusUpdatedConsumer>();

    public LeadUpdatedConsumer(ILogger<LeadUpdatedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<LeadUpdated> context)
    {
        _logger.Information("Received message: updete lead info {Text}", context.Message.Id);

        await Task.CompletedTask;
    }
}
