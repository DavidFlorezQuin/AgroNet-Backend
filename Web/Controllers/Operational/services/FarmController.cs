using Business.Operational.Interface;
using Business.Operational.services;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class FarmController : BaseController<FarmDto, IFarmBusiness>
    {
        private readonly IFarmBusiness _farmBusiness;
        public FarmController(IFarmBusiness farmBusiness) : base(farmBusiness)
        {
            _farmBusiness = farmBusiness;
        }



        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<FarmDto>>>> GetFarmsByUser(int userId)
        {

            var farms = await _farmBusiness.MapFarmDto(userId);

            if (farms == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new ApiResponse<IEnumerable<FarmDto>>(false, "An error occurred while retrieving the list: "));
            }

            return Ok(new ApiResponse<IEnumerable<FarmDto>>(true, "Entities retrieved successfully", farms));

        }
    }
}
