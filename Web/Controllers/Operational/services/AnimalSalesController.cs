using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    public class AnimalSalesController : BaseController<AnimalSaleDto, IAnimalSaleBusiness>
    {
        private readonly IAnimalSaleBusiness _animalBusiness;
        public AnimalSalesController(IAnimalSaleBusiness animalSaleBusiness) : base(animalSaleBusiness)
        {
            _animalBusiness = animalSaleBusiness;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AnimalSaleDto>>> GetAnimalSaleAsync(int farmId)
        {
            try
            {
                var animaleSale = await _animalBusiness.GetAnimalSaleAsync(farmId);

                if (animaleSale == null || animaleSale.Count == 0)
                {
                    return Ok(new ApiResponse<List<AnimalSaleDto>>(true, "No producciones found for the specified farm.", new List<AnimalSaleDto>()));

                }

                return Ok(new ApiResponse<List<AnimalSaleDto>>(true, "Entities retrieved successfully", animaleSale));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las producciones: {ex.Message}");

            }
        }


    }
}
