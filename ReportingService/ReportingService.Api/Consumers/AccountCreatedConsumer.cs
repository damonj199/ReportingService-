using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class AccountCreatedConsumer : IConsumer<AccountCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountCreatedConsumer>();
    private readonly IAccountsService _accountsService;

    public AccountCreatedConsumer(ILogger<AccountCreatedConsumer> logger, IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }
    public async Task Consume(ConsumeContext<AccountCreated> context)
    {
        _logger.Information("Received message: account created {Text}", context.Message.Id);

        var account = new AccountDto
        {
            Id = context.Message.Id,
            Currency = context.Message.Currency,
            Status = context.Message.Status,
            LeadId = context.Message.LeadId,
        };

        await _accountsService.AddAccountAsync(account);
    }
}
