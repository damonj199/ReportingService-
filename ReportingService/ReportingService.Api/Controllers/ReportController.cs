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
        _logger.Information("передаем id в сервис для поиска лида");
        var leadId = await _leadService.GetLeadFullInfoByIdAsync(id);

        return Ok(leadId);
    }

    [HttpGet("/leads-with-transactions-and-birthday")]
    public async Task<ActionResult<List<LeadForStatusUpdateResponse>>> GetLeadsWithBirthdayTodayAsync(int countDays)
    {
        _logger.Information("идем в сервис за данными");
        var leads = await _leadService.GetLeadsWithBirthdayTodayAsync(countDays);

        return Ok(leads);
    }
}
