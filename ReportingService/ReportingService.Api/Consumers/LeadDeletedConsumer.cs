using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class LeadDeletedConsumer : IConsumer<LeadDeleted>
{
    private readonly ILogger<LeadDeletedConsumer> _logger;

    public LeadDeletedConsumer(ILogger<LeadDeletedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<LeadDeleted> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
