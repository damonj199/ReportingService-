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

    [HttpGet("/lead-fullInfo-byId")]
    public async Task<ActionResult<LeadResponse>> GetLeadFullInfoByIdAsync(Guid id)
    {
        _logger.Information("Get lead with full information by id -> service");
        var leadId = await _leadService.GetLeadFullInfoByIdAsync(id);

        return Ok(leadId);
    }

    [HttpGet("/leads-birthdate")]
    public async Task<ActionResult<List<LeadsBirthDateResponse>>> GetLeadsWithBirthdayAsync(int periodBdate)
    {
        _logger.Information("Let's go -> service to look for someone's birthday");
        var leads = await _leadService.GetLeadsWithBirthdayAsync(periodBdate);

        return Ok(leads);
    }
}
