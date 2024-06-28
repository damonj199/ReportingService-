using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class AccountUpdatedStatusConsumer : IConsumer<AccountUpdatedStatus>
{
    private readonly ILogger<AccountUpdatedStatusConsumer> _logger;

    public AccountUpdatedStatusConsumer(ILogger<AccountUpdatedStatusConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<AccountUpdatedStatus> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
