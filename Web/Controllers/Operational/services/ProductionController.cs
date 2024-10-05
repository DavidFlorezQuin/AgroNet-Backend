using Business.Operational.Interface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class ProductionController : BaseController<ProductionDto, IProductionsBusiness>
    {

        private readonly IProductionsBusiness _productionsBusiness;
        public ProductionController(IProductionsBusiness productionsBusiness) : base(productionsBusiness) {
            _productionsBusiness = productionsBusiness; 
        }


        [HttpGet("production-animal/{idAnimal}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductionDto>>>> GetProductionAnimal(int idAnimal) {

            var production = await _productionsBusiness.GetProductionAnimal(idAnimal);

            if(production == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new ApiResponse<IEnumerable<ProductionDto>>(false, "An error occurred while retrieving the list: "));
            }
            return Ok(new ApiResponse<IEnumerable<ProductionDto>>(true, "Entities retrieved successfully", production));

        }

    }
}
