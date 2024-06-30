using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadCreatedConsumer : IConsumer<LeadCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadCreatedConsumer>();

    public LeadCreatedConsumer(ILogger<LeadCreatedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<LeadCreated> context)
    {
        _logger.Information("Received message: lead created {Text}", context.Message.Name);

        await Task.CompletedTask;
    }
}
