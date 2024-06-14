using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using Serilog;

namespace ReportingService.Api.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportController : Controller
    {
        private readonly ILeadsService _leadService;
        private readonly IAccountsService _accountService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, ILeadsService leadService, IAccountsService accountsService)
        {
            _leadService = leadService;
            _accountService = accountsService;
        }

        [HttpGet("/lead-fullInfo-byId/{id}")]
        public async Task<ActionResult<LeadResponse>> GetLeadFullInfoByIdAsync(Guid id)
        {
            _logger.Information("передаем id в сервис для поиска лида");
            var leadId = await _leadService.GetLeadFullInfoByIdAsync(id);

            return Ok(leadId);
        }

        [HttpGet("/leads-with-transactions")]
        public async Task<ActionResult<List<LeadForStatusUpdateResponse>>> LeadWithTransactionsResponseAsync(int countDays)
        {
            _logger.Information("получаем пертод дней для отчета и передаем их в сервис");
            var leads = await _leadService.LeadWithTransactionsResponseAsync(countDays);

            return Ok(leads);
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountForStatusUpdateResponse>>> LeadsIdFromAccountsAsync(int countDays)
        {
            _logger.Information("получаем пертод дней для отчета и передаем их в сервис");
            var account = await _accountService.LeadsIdFromAccountsAsync(countDays);

            return Ok(account);
        }
    }
}
