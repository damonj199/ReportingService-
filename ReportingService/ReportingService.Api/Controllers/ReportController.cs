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
        //private readonly IReportsService _reportsService;
        private readonly ILeadsService _accountService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, ILeadsService accountsService)
        {
            _accountService = accountsService;
        }

        [HttpGet("/lead")]
        public async Task<ActionResult<LeadResponse>> GetLeadByIdAsync(Guid Id)
        {
            _logger.Information("проверяем работат или нет");
            var leadId = await _accountService.GetLeadByIdAsync(Id);

            return Ok(leadId);
        }

        [HttpGet("/leads")]
        public async Task<ActionResult<List<LeadResponse>>> GetLeadsAsync()
        {
            _logger.Information("почему то все еще не пишет логи в консоль!!!");
            var leads = await _accountService.GetLeadsAsync();

            return Ok(leads);
        }
    }
}
