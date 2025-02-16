using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class CategoryMedicinesController : BaseController<CategoryMedicinesDto, ICategoryMedicinesBusiness>
    {
        private readonly ICategoryMedicinesBusiness _business; 
        public CategoryMedicinesController(ICategoryMedicinesBusiness categoryMedicinesBusiness) : base(categoryMedicinesBusiness) { _business = categoryMedicinesBusiness; }


        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<CategoryMedicinesDto>>> GetDiseaseAsync(int userId)
        {
            try
            {
                var obj = await _business.GetCategoryMedicinesAsync(userId);
                return Ok(new ApiResponse<List<CategoryMedicinesDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<CategoryMedicinesDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }
    }
}
