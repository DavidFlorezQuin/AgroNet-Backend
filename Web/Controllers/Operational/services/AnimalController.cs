using Business.Operational.Interface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AnimalController : BaseController<AnimalDto, IAnimalBusiness>
    {

        private readonly IAnimalBusiness _animalBusiness;


        public AnimalController(IAnimalBusiness animalBusiness) : base(animalBusiness)
        {
            _animalBusiness = animalBusiness;
        }

        [HttpGet("farm/{farmId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<AnimalDto>>>> GetAnimalsFarm(int farmId)
        {

            var animals = await _animalBusiness.GetAnimalsFarm(farmId);

            if (animals == null)
            {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                         new ApiResponse<IEnumerable<AnimalDto>>(false, "An error occurred while retrieving the list: "));
            }

            return Ok(new ApiResponse<IEnumerable<AnimalDto>>(true, "Entities retrieved successfully", animals));

        }
    }

}
