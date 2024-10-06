using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class SaleController : BaseController<SaleDto, ISaleBusiness>
    {

        private readonly ISaleData _data;
        public SaleController(ISaleBusiness saleBusiness, ISaleData data) : base(saleBusiness)
        {
            _data = data;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<SaleDto>>> GetAlerts(int farmId)
        {
            try
            {
                var sale = await _data.GetProductionAsync(farmId);

                // Verificar si la lista está vacía
                if (sale == null || sale.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<SaleDto>>(false, "An error occurred while retrieving the list: "));
                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<SaleDto>>(true, "Entities retrieved successfully", sale));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
