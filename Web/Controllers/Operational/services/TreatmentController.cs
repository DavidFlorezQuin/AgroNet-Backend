using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class TreatmentController : BaseController<TreatmentDto, ITreatmentsBusiness>
    {
        private readonly ITreatmentsData _data; 
        public TreatmentController(ITreatmentsBusiness treatmentsBusiness, ITreatmentsData data) : base(treatmentsBusiness) {

            _data = data; 
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<TreatmentDto>>> GetTreatmentAsync(int farmId)
        {
            try
            {
                var treatments = await _data.GetTreatmentAsync(farmId);

                // Verificar si la lista está vacía
                if (treatments == null || treatments.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<TreatmentDto>>(false, "An error occurred while retrieving the list: "));
                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<TreatmentDto>>(true, "Entities retrieved successfully", treatments));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
