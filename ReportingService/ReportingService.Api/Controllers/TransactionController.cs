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
        public async Task<ActionResult<List<TransactionResponse>>> GetAllTransactionAsync()
        {
            _logger.Information($"ReportingService - TransactionController - GetInformationAllTransaction");
            var transactions = await _transactionsService.GetAllTransactionAsync();

            return Ok(transactions);
        }

        [HttpGet("by-lead/{leadId}")]
        public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByLeadIdAsynk(Guid leadId)
        {
            _logger.Information($"ReportingService - TransactionController - GetInformationByAccountIdAsync");
            var transactions = await _transactionsService.GetTransactionsByLeadIdAsynk(leadId);

            return Ok(transactions);
        }

        [HttpGet("by-account/{accountId}")]
        public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByAccountIdAsynk(Guid accountId)
        {
            _logger.Information($"ReportingService - TransactionController - GetTransactionsByAccountIdAsynk");
            var transactions = await _transactionsService.GetTransactionsByAccountIdAsynk(accountId);

            return Ok(transactions);
        }
    }
}
