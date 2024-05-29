using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;

namespace ReportingService.Api.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportController : Controller
    {
        private readonly IReportsService _reportsService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger, IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }

        [HttpGet()]
        public ActionResult<Guid> GetReportById()
        {
            return Ok();
        }
    }
}
