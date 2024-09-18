using Microsoft.AspNetCore.Mvc;
using Utilities.AlertsService;

namespace Web.Controllers.Utilities
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly AlertService _alertService;

        public AlertController(AlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet("check")]
        public IActionResult CheckAlerts()
        {
            _alertService.CheckAlerts();
            return Ok("Alertas verificadas.");
        }
    }

}
