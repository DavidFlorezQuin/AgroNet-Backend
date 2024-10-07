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
        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<AnimalDto>>> GetAlerts(int farmId)
        {
            try
            {
                var birth = await _data.GetAnimalAsync(farmId);

                // Verificar si la lista está vacía
                if (birth == null || birth.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<AnimalDto>>(false, "Lista sin datos"));
                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<AnimalDto>>(true, "Entities retrieved successfully", birth));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }


    }

}
