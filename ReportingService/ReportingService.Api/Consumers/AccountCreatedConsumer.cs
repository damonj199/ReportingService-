using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class AccountCreatedConsumer : IConsumer<AccountCreated>
{
    private readonly ILogger<AccountCreatedConsumer> _logger;

    public AccountCreatedConsumer(ILogger<AccountCreatedConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<AccountCreated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
