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
            //_reportsService = reportsService;
            _accountService = accountsService;

        }

        [HttpGet("/lead")]
        public ActionResult<LeadResponse> GetLeadById(Guid Id)
        {
            _logger.Information("проверяем работат или нет");
            return Ok(_accountService.GetLeadById(Id));
        }

        [HttpGet("/leads")]
        public ActionResult<List<LeadResponse>> GetLeads()
        {
            return Ok(_accountService.GetLeads());
        }
    }
}
