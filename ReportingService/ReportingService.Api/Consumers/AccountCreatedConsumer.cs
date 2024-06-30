using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class AccountCreatedConsumer : IConsumer<AccountCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountCreatedConsumer>();

    public AccountCreatedConsumer(ILogger<AccountCreatedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<AccountCreated> context)
    {
        _logger.Information("Received message: account created {Text}", context.Message.Id);

        await Task.CompletedTask;
    }
}
