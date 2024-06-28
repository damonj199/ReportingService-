using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class AccountBlockedConsumer : IConsumer<AccountBlocked>
{
    private readonly ILogger<AccountBlockedConsumer> _logger;

    public AccountBlockedConsumer(ILogger<AccountBlockedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<AccountBlocked> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
