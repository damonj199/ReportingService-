using MassTransit;
using ReportingService.Api.Consumers;

namespace ReportingService.Api.Consumer;

public class Consumer : IConsumer<YourMessage>
{
    private readonly ILogger<Consumer> _logger;

    public Consumer(ILogger<Consumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<YourMessage> context)
    {
        _logger.LogInformation("Received message: {Text}", context.Message.Text);
        // Обработка сообщения
        await Task.CompletedTask;
    }
}
