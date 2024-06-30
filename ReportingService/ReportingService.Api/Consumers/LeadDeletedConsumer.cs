using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadDeletedConsumer : IConsumer<LeadDeleted>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadDeletedConsumer>();

    public LeadDeletedConsumer(ILogger<LeadDeletedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<LeadDeleted> context)
    {
        _logger.Information("Received message: lead daleted {Text}", context.Message.Id);

        await Task.CompletedTask;
    }
}
