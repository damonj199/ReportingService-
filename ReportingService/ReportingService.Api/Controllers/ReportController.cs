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
        private readonly IReportsService _reportsService;
        private readonly Serilog.ILogger _logger = Log.ForContext<ReportController>();

        public ReportController(ILogger<ReportController> logger, IReportsService reportsService)
        {
           // _logger = logger;
            _reportsService = reportsService;
        }

        [HttpGet()]
        public ActionResult<Guid> GetReportById()
        {
            return Ok();
        }


       
    }
}
