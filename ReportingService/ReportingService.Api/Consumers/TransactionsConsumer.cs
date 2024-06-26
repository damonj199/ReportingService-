using MassTransit;
using Messaging.Shared;

namespace ReportingService.Api.Consumer;

public class TransactionsConsumer : IConsumer<TransactionCreated>
{
    private readonly ILogger<TransactionsConsumer> _logger;

    public TransactionsConsumer(ILogger<TransactionsConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<TransactionCreated> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message);

        await Task.CompletedTask;
    }
}
