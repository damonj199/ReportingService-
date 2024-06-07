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
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, ILeadsService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet("/lead/{id}")]
        public async Task<ActionResult<LeadResponse>> GetLeadByIdAsync(Guid id)
        {
            _logger.Information("передаем id в сервис для поиска лида");
            var leadId = await _leadService.GetLeadByIdAsync(id);

            return Ok(leadId);
        }

        [HttpGet("/leads-with-transactions")]
        public async Task<ActionResult<List<LeadForStatusUpdateResponse>>> GetAllInfoLeadsAsync(int countDays)
        {
            _logger.Information("получаем пертод дней для отчета и передаем их в сервис");
            var leads = await _leadService.GetAllInfoLeadsAsync(countDays);

            return Ok(leads);
        }
    }
}
