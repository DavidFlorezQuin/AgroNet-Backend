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

        [HttpGet("datatable")]
        public async Task<ActionResult<List<AlertDto>>> GetAlerts()
        {
            try
            {
                var alerts = await _alertData.GetAlertsAsync();

                // Verificar si la lista está vacía
                if (alerts == null || alerts.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<AlertDto>>(false, "An error occurred while retrieving the list: "));
                }

                // Devolver la lista de alertas
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
