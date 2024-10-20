using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AnimalController : BaseController<AnimalDto, IAnimalBusiness>
    {

        private readonly IAnimalBusiness _animalBusiness;
        private readonly IAnimalData _data;

        public AnimalController(IAnimalBusiness animalBusiness, IAnimalData data) : base(animalBusiness)
        {
            _animalBusiness = animalBusiness;
            _data = data;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimals(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimalAsync(farmId);

                // Verificar si la lista está vacía
                if (animal == null || animal.Count == 0)
                {
                    return Ok(new ApiResponse<List<AnimalDto>>(true, "No animals found for the specified farm.", new List<AnimalDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
        [HttpGet("datatable/cows/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalsCows(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimalFemaleAsync(farmId);

                if (animal == null || animal.Count == 0)
                {
                    return Ok(new ApiResponse<List<AnimalDto>>(true, "No alerts found for the specified farm.", new List<AnimalDto>()));
                }

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

        [HttpGet("datatable/bulls/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalsBulls(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimaMalelAsync(farmId);

                // Verificar si la lista está vacía
                if (animal == null || animal.Count == 0)
                {
                    return Ok(new ApiResponse<List<AnimalDto>>(true, "No alerts found for the specified farm.", new List<AnimalDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }


    }

}
