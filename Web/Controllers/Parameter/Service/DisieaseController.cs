using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class DisieaseController : BaseController<DiseaseDto, IDiseaseBusiness>
    {
        private readonly IDiseaseBusiness _business;

        public DisieaseController(IDiseaseBusiness diseaseBusiness) : base(diseaseBusiness) { _business = diseaseBusiness;  }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<DiseaseDto>>> GetDiseaseAsync(int userId)
        {
            try
            {
                var obj = await _business.GetDiseaseAsync(userId);
                return Ok(new ApiResponse<List<DiseaseDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<DiseaseDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }
    }
}
