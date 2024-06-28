using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class LeadUpdatedConsumer : IConsumer<LeadUpdated>
{
    private readonly ILogger<LeadUpdatedConsumer> _logger;

    public LeadUpdatedConsumer(ILogger<LeadUpdatedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<LeadUpdated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
