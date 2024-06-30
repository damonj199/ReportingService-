using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class AccountBlockedConsumer : IConsumer<AccountBlocked>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountBlockedConsumer>();

    public AccountBlockedConsumer(ILogger<AccountBlockedConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<AccountBlocked> context)
    {
        _logger.Information("Received message: account blocked {Text}", context.Message.Id);

        await Task.CompletedTask;
    }
}
