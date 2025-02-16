using Business.Exceptions;
using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class CategoryAlertController : BaseController<CategoryAlertDto, ICategoryAlertBusiness>
    {
        private readonly ICategoryAlertBusiness _business;
        public CategoryAlertController(ICategoryAlertBusiness categoryAlertBusiness) : base(categoryAlertBusiness) { _business = categoryAlertBusiness; }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<CategoryAlertDto>>> GetCategoryAlertDtoAsync(int userId)
        {
            try
            {
                var obj = await _business.GetCategoryAlertAsync(userId);
                return Ok(new ApiResponse<List<CategoryAlertDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<CategoryAlertDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }

        [HttpPost("saveAll")]
        public async Task<ActionResult<CategoryAlertDto>> SaveAllFarms(CategoryAlertDto dto, int userId)
        {
            try
            {
                var obj = await _business.SaveAllFarms(dto, userId);
                return Ok(new ApiResponse<CategoryAlertDto>(true, "Datos recuperados exitosamente", obj));
            }catch(FarmNotFoundException ex)
            {
                return BadRequest(new ApiResponse<CategoryAlertDto>(false, ex.Message));
            }catch(Exception ex)
            {
                return StatusCode(500, new ApiResponse<CategoryAlertDto>(false, $"Ocurrió un error inesperado{ex.Message}"));

            }
        }

    }
}
