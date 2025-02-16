using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class SuppliesController : BaseController<SuppliesDto, ISuppliesBusiness>
    {
        private readonly ISuppliesBusiness _business;
        public SuppliesController(ISuppliesBusiness suppliesBusiness) : base(suppliesBusiness) {
            _business = suppliesBusiness;
        }
        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<SuppliesDto>>> GetSuppliesAsync(int userId)
        {
            try
            {
                var supplies = await _business.GetSuppliesAsync(userId);
                return Ok(new ApiResponse<List<SuppliesDto>>(true, "Datos recuperados exitosamente", supplies));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<SuppliesDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las insumos: {ex.Message}");
            }
        }
    }
}
