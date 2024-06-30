using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class AccountUpdatedStatusConsumer : IConsumer<AccountUpdatedStatus>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountUpdatedStatusConsumer>();

    public AccountUpdatedStatusConsumer(ILogger<AccountUpdatedStatusConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<AccountUpdatedStatus> context)
    {
        _logger.Information("Received message: update status {Text}", context.Message.Status);

        await Task.CompletedTask;
    }
}
