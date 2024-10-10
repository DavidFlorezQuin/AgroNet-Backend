using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class LotController : BaseController<LotsDto, ILotBusiness>
    {
        private readonly ILotData _data; 
        public LotController(ILotBusiness lotBusiness, ILotData data) : base(lotBusiness) {
            _data = data; 
        }
        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<LotsDto>>> GetAlerts(int farmId)
        {
            try
            {
                var lots = await _data.GetLotsAsync(farmId);

                // Verificar si la lista está vacía
                if (lots == null || lots.Count == 0)
                {
                    return Ok(new ApiResponse<List<LotsDto>>(true, "No alerts found for the specified farm.", new List<LotsDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<LotsDto>>(true, "Entities retrieved successfully", lots));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
