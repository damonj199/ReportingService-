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
        private readonly ILeadsService _leadService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, ILeadsService leadService, IPublishEndpoint publishEndpoint)
        {
            _leadService = leadService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("/lead/{id}")]
        public async Task<ActionResult<LeadResponse>> GetLeadByIdAsync(Guid id)
        {
            _logger.Information("�������� id � ������ ��� ������ ����");
            var leadId = await _leadService.GetLeadByIdAsync(id);

            return Ok(leadId);
        }

        [HttpGet("/leads/by-day/{count-days}")]
        public async Task<ActionResult<List<LeadResponse>>> GetAllInfoLeadsAsync(int countDays)
        {
            _logger.Information("�������� ������ ���� ��� ������ � �������� �� � ������");
            var leads = await _leadService.GetAllInfoLeadsAsync(countDays);

            return Ok(leads);
        }
    }
}
