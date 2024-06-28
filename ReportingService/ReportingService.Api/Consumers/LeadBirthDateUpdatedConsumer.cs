using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class LeadBirthDateUpdatedConsumer :IConsumer<LeadBirthDateUpdated>
{
    private readonly ILogger<LeadBirthDateUpdatedConsumer> _logger;

    public LeadBirthDateUpdatedConsumer(ILogger<LeadBirthDateUpdatedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<LeadBirthDateUpdated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
