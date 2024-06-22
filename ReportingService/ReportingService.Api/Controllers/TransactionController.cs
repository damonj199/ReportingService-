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


        [HttpGet()]
        public async Task<ActionResult<List<TransactionResponse>>> GetAllTransactionsAsync()
        {
            _logger.Information($"ReportingService - TransactionController - GetInformationAllTransaction");
            var transactions = await _transactionsService.GetAllTransactionsAsync();

            return Ok(transactions);
        }

        //[HttpGet("by-lead/{leadId}")]
        //public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByLeadIdAsync(Guid leadId)
        //{
        //    _logger.Information($"ReportingService - TransactionController - GetInformationByAccountIdAsync");
        //    var transactions = await _transactionsService.GetTransactionsByLeadIdAsync(leadId);

        //    return Ok(transactions);
        //}

        [HttpGet("by-period")]
        public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByPeriodDayAsync(int countDays)
        {
            _logger.Information($"ReportingService - TransactionController - GetTransactionsByAccountIdAsynk");
            var transactions = await _transactionsService.GetTransactionsByPeriodDayAsync(countDays);

            return Ok(transactions);
        }

        [HttpGet("accounts-negaiv-balace")]
        public async Task<ActionResult<List<NegativBalanceResponse>>> GetAccountsNegativBalanceAsync()
        {
            _logger.Information("просим, очень сильно, сервис принять данные и вурнуть Response");
            var negBalance = await _transactionsService.GetAccountsNegativBalanceAsync();

            return Ok(negBalance);
        }
    }
}
