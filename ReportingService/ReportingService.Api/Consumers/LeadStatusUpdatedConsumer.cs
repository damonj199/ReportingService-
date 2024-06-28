using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class LeadStatusUpdatedConsumer : IConsumer<LeadStatusUpdated>
{
    private readonly ILogger<LeadStatusUpdatedConsumer> _logger;

    public LeadStatusUpdatedConsumer(ILogger<LeadStatusUpdatedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<LeadStatusUpdated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
