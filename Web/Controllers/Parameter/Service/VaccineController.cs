using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class VaccineController : BaseController<VaccineDto, IVaccineBusiness>
    {
        private readonly IVaccineBusiness _business;
        public VaccineController(IVaccineBusiness vaccineBusiness) : base(vaccineBusiness)
        {
            _business = vaccineBusiness;
        }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<VaccineDto>>> GetVaccineAsync(int userId)
        {
            try
            {
                var vaccine = await _business.GetVaccineAsync(userId);
                return Ok(new ApiResponse<List<VaccineDto>>(true, "Datos encontrados", vaccine));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message)); 
            }

        }
    }
}
