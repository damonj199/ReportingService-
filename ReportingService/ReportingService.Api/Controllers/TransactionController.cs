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
        public async Task<ActionResult<List<TransactionResponse>>> GetInformationAllTransactionAsync()
        {
            _logger.Information($"ReportingService - TransactionController - GetInformationAllTransaction");
            var transactions = await _transactionsService.GetInformationAllTransactionAsync();

            return Ok(transactions);
        }
    }
}
