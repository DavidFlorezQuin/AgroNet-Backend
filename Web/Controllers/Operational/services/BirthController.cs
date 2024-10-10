using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class BirthController : BaseController<BirthDto, IBirthBusiness>
    {
        private readonly IBirthData _data; 
        public BirthController(IBirthBusiness birthBusiness, IBirthData data) : base(birthBusiness) {
            _data = data; 
        }
        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<BirthDto>>> GetAlerts(int farmId)
        {
            try
            {
                var birth = await _data.GetBirthAsync(farmId);

                // Verificar si la lista está vacía
                if (birth == null || birth.Count == 0)
                {
                    return Ok(new ApiResponse<List<BirthDto>>(true, "No alerts found for the specified farm.", new List<BirthDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<BirthDto>>(true, "Entities retrieved successfully", birth));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
