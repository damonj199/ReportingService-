using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadBirthDateUpdatedConsumer :IConsumer<LeadBirthDateUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadBirthDateUpdatedConsumer>();

    public LeadBirthDateUpdatedConsumer(ILogger<LeadBirthDateUpdatedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<LeadBirthDateUpdated> context)
    {
        _logger.Information("Received message: update Bdate {Text}", context.Message.BirthDate);

        await Task.CompletedTask;
    }
}
