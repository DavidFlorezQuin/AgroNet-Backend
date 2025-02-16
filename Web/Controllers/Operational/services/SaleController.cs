using Business.Exceptions;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class SaleController : BaseController<SaleDto, ISaleBusiness>
    {

        private readonly ISaleData _data;
        private readonly ISaleBusiness _business;
        public SaleController(ISaleBusiness saleBusiness, ISaleData data) : base(saleBusiness)
        {
            _data = data;
            _business = saleBusiness;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<SaleDto>>> GetAlerts(int farmId)
        {
            try
            {
                var sale = await _data.GetSaleAsync(farmId);

                if (sale == null || sale.Count == 0)
                {
                    return Ok(new ApiResponse<List<SaleDto>>(true, "No alerts found for the specified farm.", new List<SaleDto>()));
                }

                return Ok(new ApiResponse<List<SaleDto>>(true, "Entities retrieved successfully", sale));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

        [HttpPost("save-sale")]
        public async Task<IActionResult> CreateResult([FromBody] SaleDto saleDto)
        {
            try
            {
                var result = await _business.SaveAsync(saleDto);
                return Ok(new ApiResponse<SaleDto>(true, "Datos registrados", result));

            } catch (ProductionNotFoundException ex)
            {
                return NotFound(new ApiResponse<bool>(false, ex.Message));

            }
            catch (InsufficientStockException ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message));
            }
            catch (Exception ex) {
                return StatusCode(500, new ApiResponse<bool>(false, ex.Message)); 
            }
        }

        [HttpGet("monthly-sale/{farmId}")]
        public async Task<IActionResult> GetMonthlySale(int farmId)
        {
            try
            {
                // Obtener los datos de producción para la granja específica
                var data = await _data.GetMonthlySale(farmId);

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
