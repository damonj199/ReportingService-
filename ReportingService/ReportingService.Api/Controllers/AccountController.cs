using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using Serilog;

namespace ReportingService.Api.Controllers;

[ApiController]
[Route("/api/accounts")]
public class AccountController : Controller
{
    private readonly IAccountsService _accountService;
    private readonly Serilog.ILogger _logger = Log.ForContext<AccountController>();

    public AccountController(ILogger<AccountController> logger, IAccountsService accountsService)
    {
        _accountService = accountsService;
    }

    [HttpGet("/with-transactions")]
    public async Task<ActionResult<List<AccountForStatusUpdateResponse>>> AccountsWithTransactionsResponseAsync(int countDays)
    {
        _logger.Information("получаем период дней для отчета и передаем их в сервис");
        var account = await _accountService.AccountsWithTransactionsResponseAsync(countDays);

        return Ok(account);
    }
}
