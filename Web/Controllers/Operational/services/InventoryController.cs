using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InventoryController : BaseController<InventoriesDto, IInventoriesBusiness>
    {
        private readonly IInventoryData _data; 
        public InventoryController(IInventoriesBusiness inventoriesBusiness, IInventoryData data) : base(inventoriesBusiness) {
            _data = data; 
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<InventoriesDto>>> GetAlerts(int farmId)
        {
            try
            {
                var inventory = await _data.GetInventoryAsync(farmId);

                // Verificar si la lista está vacía
                if (inventory == null || inventory.Count == 0)
                {
                    return Ok(new ApiResponse<List<InventoriesDto>>(true, "No alerts found for the specified farm.", new List<InventoriesDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<InventoriesDto>>(true, "Entities retrieved successfully", inventory));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
