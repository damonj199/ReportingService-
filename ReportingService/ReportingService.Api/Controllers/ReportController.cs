using Microsoft.AspNetCore.Mvc;
using ReportingService.Bll.IServices;

namespace ReportingService.Api.Controllers
{
    [ApiController]
    [Route("/api/report")]
    public class ReportController : Controller
    {
        private readonly IReportServices _reportsService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger, IReportServices reportServices)
        {
            _logger = logger;
            _reportsService = reportServices;
        }

        [HttpGet()]
        public ActionResult<Guid> GetReportById()
        {
            return Ok(_reportsService.GetReportById());
        }
    }
}
