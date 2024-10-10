
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InventorySuppliesController : BaseController<InventorySuppliesDto, IInventorySuppliesBusiness>
    {
        private readonly IInventoySuppliesData _data;
        public InventorySuppliesController(IInventorySuppliesBusiness inventorySuppliesBusiness, IInventoySuppliesData data) : base(inventorySuppliesBusiness) {
            _data = data;
        }

        [HttpGet("datatable/{inventoryId}")]
        public async Task<ActionResult<List<InventorySuppliesDto>>> GetAlerts(int inventoryId)
        {
            try
            {
                var supplies = await _data.GetInventorySuppliesAsync(inventoryId);

                // Verificar si la lista está vacía
                if (supplies == null || supplies.Count == 0)
                {
                    return Ok(new ApiResponse<List<InventorySuppliesDto>>(true, "No alerts found for the specified farm.", new List<InventorySuppliesDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<InventorySuppliesDto>>(true, "Entities retrieved successfully", supplies));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
    }
}
