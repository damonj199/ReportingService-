using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class AccountUpdatedStatusConsumer : IConsumer<AccountUpdatedStatus>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountUpdatedStatusConsumer>();
    private readonly IAccountsService _accountsService;

    public AccountUpdatedStatusConsumer(ILogger<AccountUpdatedStatusConsumer> logger, IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }
    public async Task Consume(ConsumeContext<AccountUpdatedStatus> context)
    {
        _logger.Information("Received message: update status {Text}", context.Message.Status);

        var accountUpdatedStatus = new AccountDto { Id = context.Message.Id, Status = context.Message.Status };

        await _accountsService.UpdateAccountAsync(accountUpdatedStatus);
    }
}
