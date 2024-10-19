using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AlertController : BaseController<AlertDto, IAlertBusiness>
    {
        private readonly IAlertData _alertData;
        private readonly IAlertBusiness _alertBusiness;
        public AlertController(IAlertBusiness alertBusiness, IAlertData alertData) : base(alertBusiness) {
            _alertData = alertData;
            _alertBusiness = alertBusiness;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AlertDto>>> GetAlerts(int farmId)
        {
            try
            {
                var alerts = await _alertData.GetAlertsAsync(farmId);

                if (alerts == null || alerts.Count == 0)
                {
                    return Ok(new ApiResponse<List<AlertDto>>(true, "No alerts found for the specified farm.", new List<AlertDto>()));
                }

                return Ok(new ApiResponse<List<AlertDto>>(true, "Entities retrieved successfully", alerts));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

        [HttpGet("GetAlertsNotReads/{farmId}")]
        public async Task<ActionResult<List<AlertDto>>> GetAlertsNotRead(int farmId)
        {
            try
            {
                var alerts = await _alertBusiness.GetAlertsNotReads(farmId);
                return Ok(new ApiResponse<List<AlertDto>>(true, "Alerts retrieved successfully", alerts));
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<List<AlertDto>>(false, ex.Message));
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<List<AlertDto>>(false, "An error ocurred" + ex.Message)); 
            }
        }

        [HttpPut("AlertRead/{alertId}")]
        public async Task<ActionResult> MarkReadAlert(int alertId)
        {
            try { 
            await _alertBusiness.AlertIsRead(alertId);
            return Ok(new ApiResponse<bool>(true, "Alerts retrieved successfully"));

            } catch(ArgumentException ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message));
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<bool>(false, "An error ocurred" + ex.Message));
            }
        }

    }
}
