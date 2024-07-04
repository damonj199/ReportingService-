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
        _logger.Information($"Received message: Message received and read");
        var transactionCreated = context.Message;

        var transactionDto = new TransactionDto
        {
            Id = transactionCreated.Id,
            Account = new AccountDto { Id = transactionCreated.AccountId },
            TransactionType = transactionCreated.TransactionType,
            Amount = transactionCreated.Amount,
            CommissionAmount = transactionCreated.CommissionAmount,
            Currency = transactionCreated.Currency,
            Date = transactionCreated.Date,
            AmountInRUB = transactionCreated.AmountInRUB
        };

        await _transactionsService.AddTransactions(transactionDto);
    }
}
