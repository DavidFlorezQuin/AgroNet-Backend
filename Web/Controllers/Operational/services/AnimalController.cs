using Business.Exceptions;
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

        [HttpGet("datatable/register/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimals(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimalAsync(farmId);

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            } catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }
        [HttpGet("datatable/cows/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalsCows(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimalFemaleAsync(farmId);

               return Ok(new ApiResponse<List<AnimalDto>>(true, "Data cargada.", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            }
            catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }

        [HttpGet("datatable/bulls/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalsBulls(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimaMalelAsync(farmId);

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            }
            catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalAsync(int farmId)
        {
            try
              {
                var animal = await _data.GetAnimalAsync(farmId);

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            }
            catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }

        [HttpGet("cows/milk/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetCowAvailableMilk(int farmId)
        {
            try
            {
                var animal = await _data.GetCowAvailableMilk(farmId);

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            }
            catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }

        [HttpGet("cows/available-insemination/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAnimalAvailableInsemination(int farmId)
        {
            try
            {
                var animal = await _data.GetAnimalAvailableInsemination(farmId);

                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", animal));
            }
            catch (FarmNotFoundException ex)
            {
                return StatusCode(500, $"Error al obtener las fincas: {ex.Message}");

            }
            catch (AnimalsNotFoundExceptions ex)
            {
                return StatusCode(500, $"Error al obtener las animales: {ex.Message}");
            }
        }
    }

}
