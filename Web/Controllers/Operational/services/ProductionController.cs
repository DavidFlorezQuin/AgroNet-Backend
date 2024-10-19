using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class ProductionController : BaseController<ProductionDto, IProductionsBusiness>
    {
        private readonly IProductionsData _data; 
        private readonly IProductionsBusiness _productionsBusiness;
        public ProductionController(IProductionsBusiness productionsBusiness, IProductionsData data) : base(productionsBusiness) {
            _productionsBusiness = productionsBusiness;
            _data = data;
        }



        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<ProductionDto>>> GetAlerts(int farmId)
        {
            try
            {
                var produc = await _data.GetProductionAnimals(farmId);

                // Verificar si la lista está vacía
                if (produc == null || produc.Count == 0)
                {
                    return Ok(new ApiResponse<List<ProductionDto>>(true, "No alerts found for the specified farm.", new List<ProductionDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<ProductionDto>>(true, "Entities retrieved successfully", produc));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
