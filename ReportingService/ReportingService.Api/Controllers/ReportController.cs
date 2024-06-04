using MassTransit;
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
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILeadsService _accountService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, ILeadsService accountsService, IPublishEndpoint publishEndpoint)
        {
            _accountService = accountsService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("/lead")]
        public async Task<ActionResult<LeadResponse>> GetLeadByIdAsync(Guid Id)
        {
            _logger.Information("проверяем работат или нет");
            var leadId = await _accountService.GetLeadByIdAsync(Id);

            return Ok(leadId);
        }

        [HttpGet("/leads/by-day/{count}")]
        public async Task<ActionResult<List<LeadResponse>>> GetLeadsAsync(int count)
        {
            _logger.Information("почему то все еще не пишет логи в консоль!!!");
            var leads = await _accountService.GetLeadsAsync(count);

            return Ok(leads);
        }
    }
}
