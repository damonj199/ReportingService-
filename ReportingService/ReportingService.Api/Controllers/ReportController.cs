using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportController : Controller
    {
        private readonly IReportsService _reportsService;
        private readonly IAccountsService _accountService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, IReportsService reportsService, IAccountsService accountsService)
        {
            _reportsService = reportsService;
            _accountService = accountsService;

        }

        [HttpGet()]
        public ActionResult<Guid> GetReportById()
        {
            return Ok();
        }

        [HttpGet("/lead")]
        public ActionResult<LeadDto> GetLeadById(Guid Id)
        {
            _logger.Information("проверяем работат или нет");
            return Ok(_accountService.GetAccountByLeadId(Id));
        }


    }
}
