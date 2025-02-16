using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class CategorySuppliesController : BaseController<CategorySuppliesDto, ICategorySuppliesBusiness>
    {
        private readonly ICategorySuppliesBusiness _business;

        public CategorySuppliesController(ICategorySuppliesBusiness categorySuppliesBusiness) : base(categorySuppliesBusiness) { _business = categorySuppliesBusiness; }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<CategorySuppliesDto>>> GetDiseaseAsync(int userId)
        {
            try
            {
                var obj = await _business.GetCategorySuppliesAsync(userId);
                return Ok(new ApiResponse<List<CategorySuppliesDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<CategorySuppliesDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }
    }
}
