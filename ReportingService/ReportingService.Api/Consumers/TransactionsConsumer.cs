using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class TransactionsConsumer : IConsumer<TransactionCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<TransactionsConsumer>();
    private readonly ITransactionsService _transactionsService;
    public TransactionsConsumer(ILogger<TransactionsConsumer> logger, ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }
    public async Task Consume(ConsumeContext<TransactionCreated> context)
    {
        _logger.Information($"Received message: Message received and read {context.Message.Amount} {context.Message.CommissionAmount}");

        var transactionDto = new TransactionDto
        {
            Id = context.Message.Id,
            Account = new AccountDto { Id = context.Message.AccountId },
            TransactionType = context.Message.TransactionType,
            Amount = context.Message.Amount,
            CommissionAmount = context.Message.CommissionAmount,
            Currency = context.Message.Currency,
            Date = context.Message.Date,
            AmountInRUB = context.Message.AmountInRUB
        };

        await _transactionsService.AddTransactionsAsync(transactionDto);
    }
}
