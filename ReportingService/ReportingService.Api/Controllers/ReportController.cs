using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;
using ReportingService.Bll.Models.Responses;
using Serilog;

namespace ReportingService.Api.Controllers;

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

    [HttpGet("/lead-fullInfo-byId/{id}")]
    public async Task<ActionResult<LeadResponse>> GetLeadFullInfoByIdAsync(Guid id)
    {
        _logger.Information("�������� id � ������ ��� ������ ����");
        var leadId = await _leadService.GetLeadFullInfoByIdAsync(id);

        return Ok(leadId);
    }

    [HttpGet("/leads-with-transactions-and-birthday")]
    public async Task<ActionResult<List<LeadForStatusUpdateResponse>>> GetLeadsWithBirthdayTodayAsync()
    {
        _logger.Information("���� � ������ �� �������");
        var leads = await _leadService.GetLeadsWithBirthdayTodayAsync();

        return Ok(leads);
    }

    [HttpGet("dai-chto-nibyd'")]
    public async Task<ActionResult<List<LeadResponse>>> LeadWithTransactionsResponseAsync(int countDays)
    {
        _logger.Information("���� � ������ �� �������");
        var leads = await _leadService.LeadWithTransactionsResponseAsync(countDays);

        return Ok(leads);
    }
}
