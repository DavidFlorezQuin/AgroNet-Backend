using Business.Operational.Interface;
using Business.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    public class InventoryRecordsController : BaseController<InventoryRecordsDto, IInventoryRecordsBusiness>
    {

        private readonly IInventoryRecordsBusiness _business;
        public InventoryRecordsController(IInventoryRecordsBusiness inventoryRecordsBusiness) : base(inventoryRecordsBusiness) {
            _business = inventoryRecordsBusiness;
        }

        [HttpGet("datatable/{inventoryId}")]

        public async Task<ActionResult<List<InventoryRecordsDto>>> GetRecordsAsync(int inventoryId) 
        {
            try
            {
                var records = await _business.GetRecordsAsync(inventoryId);
                if (records == null || records.Count == 0)
                {
                    return Ok(new ApiResponse<List<InventoryRecordsDto>>(true, "No records found.", new List<InventoryRecordsDto>()));

                }
                return Ok(new ApiResponse<List<InventoryRecordsDto>>(true, "Entidades retrieved successfully", records));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
    }
}
