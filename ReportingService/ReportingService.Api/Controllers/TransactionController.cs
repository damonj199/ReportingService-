using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using Serilog;

namespace ReportingService.Api.Controllers
{
    [ApiController]
    [Route("/api/transactions")]
    public class TransactionController : Controller
    {
        private readonly ITransactionsService _transactionsService;
        private readonly Serilog.ILogger _logger = Log.ForContext<TransactionController>();


        public TransactionController(ILogger<TransactionController> logger, ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }


        [HttpGet("/by-id/{id}")]
        public async Task<ActionResult<TransactionResponse>> GetTransactionByIdsAsync(Guid id)
        {
            _logger.Information($"search for transactions by id {id}");
            var transactions = await _transactionsService.GetTransactionByIdsAsync(id);

            return Ok(transactions);
        }

        [HttpGet("by-period/")]
        public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByPeriodDayAsync(int countDays)
        {
            _logger.Information($"we will look for transactions for the period {countDays} days");
            var transactions = await _transactionsService.GetTransactionsByPeriodDayAsync(countDays);

            return Ok(transactions);
        }

        [HttpGet("accounts-negaiv-balace")]
        public async Task<ActionResult<List<NegativBalanceResponse>>> GetAccountsNegativBalanceAsync()
        {
            _logger.Information("provide data -> service search for accounts with a negative balance");
            var negBalance = await _transactionsService.GetAccountsNegativBalanceAsync();

            return Ok(negBalance);
        }
    }
}
