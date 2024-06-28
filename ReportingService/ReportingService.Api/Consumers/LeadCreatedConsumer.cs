using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class LeadCreatedConsumer : IConsumer<LeadCreated>
{
    private readonly ILogger<LeadCreatedConsumer> _logger;

    public LeadCreatedConsumer(ILogger<LeadCreatedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<LeadCreated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
