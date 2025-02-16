using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class CategoryDiseaseController : BaseController<CategoryDiseaseDto, ICategoryDiseaseBusiness>
    {
        private readonly ICategoryDiseaseBusiness _business;

        public CategoryDiseaseController(ICategoryDiseaseBusiness categoryDiseaseBusiness) : base(categoryDiseaseBusiness) { _business = categoryDiseaseBusiness;  }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<CategoryDiseaseDto>>> GetCategoryDiseaseDtoAsync(int userId)
        {
            try
            {
                var obj = await _business.GetCategoryDiseaseAsync(userId);
                return Ok(new ApiResponse<List<CategoryDiseaseDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<CategoryDiseaseDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }
    }
}
