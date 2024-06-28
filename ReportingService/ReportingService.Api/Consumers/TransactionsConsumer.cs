using MassTransit;
using Messaging.Shared;
using Serilog;

namespace ReportingService.Api.Consumer;

public class TransactionsConsumer : IConsumer<TransactionCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<TransactionsConsumer>();
    public TransactionsConsumer(ILogger<TransactionsConsumer> logger)
    {
    }
    public async Task Consume(ConsumeContext<TransactionCreated> context)
    {
        _logger.Information($"Received message: Message received and read");

        await Task.CompletedTask;
    }
}
