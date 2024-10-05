using Business.Operational.Interface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InseminationController : BaseController<InseminationDto, IInseminationBusiness>
    {

        private readonly IInseminationBusiness _inseminationBusiness;
        public InseminationController(IInseminationBusiness inseminationBusiness) : base(inseminationBusiness)
        {

            _inseminationBusiness = inseminationBusiness;
        }


        [HttpGet("animalInsemination/{farmId}")]

        public async Task<ActionResult<ApiResponse<IEnumerable<AnimalDto>>>> GetAnimalInsemination(int farmId)
        {
            var animals = await _inseminationBusiness.GetAnimalsInsemination(farmId);

            if (animals == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new ApiResponse<IEnumerable<AnimalDto>>(false, "An error occurred while retrieving the list: "));
            }

            return Ok(new ApiResponse<IEnumerable<AnimalDto>>(true, "Entities retrieved successfully", animals));

        }
    }
}
