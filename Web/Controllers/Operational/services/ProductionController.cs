using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Dto.Utilities;
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
                    return Ok(new ApiResponse<List<ProductionDto>>(true, "No producciones found for the specified farm.", new List<ProductionDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<ProductionDto>>(true, "Entities retrieved successfully", produc));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las producciones: {ex.Message}");
            }
        }

        [HttpGet("monthly-milk-production/{farmId}")]
        public async Task<IActionResult> GetMonthlyMilkProduction(int farmId)
        {
            try
            {
                // Obtener los datos de producción para la granja específica
                var data = await _data.GetMonthlyMilkProductionAsync(farmId);

                // Si no hay datos, retornar meses con valores en cero
                if (data == null || !data.Any())
                {
                    var emptyData = GetEmptyMonthlyData();
                    return Ok(emptyData);
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                // En caso de error, retornar meses en cero y un código de estado 500
                var emptyData = GetEmptyMonthlyData();
                return StatusCode(500, emptyData);
            }
        }

        private List<DataProductionDto> GetEmptyMonthlyData()
        {
            var months = Enumerable.Range(0, 5)
                .Select(i => DateTime.Now.AddMonths(-i).ToString("MMMM"))
                .Reverse() // Asegurar que los meses estén en orden cronológico
                .Select(m => new DataProductionDto { Mes = m, Litros = 0 })
                .ToList();

            return months;
        }

    }
}
