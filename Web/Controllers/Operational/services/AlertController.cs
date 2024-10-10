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
        public AlertController(IAlertBusiness alertBusiness, IAlertData alertData) : base(alertBusiness) { 
        _alertData = alertData;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AlertDto>>> GetAlerts(int farmId)
        {
            try
            {
                var alerts = await _alertData.GetAlertsAsync(farmId);

                // Devolver una respuesta exitosa aunque la lista esté vacía
                if (alerts == null || alerts.Count == 0)
                {
                    return Ok(new ApiResponse<List<AlertDto>>(true, "No alerts found for the specified farm.", new List<AlertDto>()));
                }

                // Devolver la lista de alertas si no está vacía
                return Ok(new ApiResponse<List<AlertDto>>(true, "Entities retrieved successfully", alerts));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }


    }
}
