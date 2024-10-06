using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AnimalDiagnosticController : BaseController<AnimalDiagnosticDto, IAnimalDiagnosticBusiness>
    {
        private readonly IAnimalDiagnosticData _Data;

        public AnimalDiagnosticController(IAnimalDiagnosticBusiness animalDiagnosticBusiness, IAnimalDiagnosticData data ) : base(animalDiagnosticBusiness) {
            _Data = data; 
        }
        [HttpGet("datatable")]
        public async Task<ActionResult<List<AnimalDiagnosticDto>>> GetAnimalDiag()
        {
            try
            {
                var animals = await _Data.GetAnimalDiagAsync();

                // Verificar si la lista está vacía
                if (animals == null || animals.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<AlertDto>>(false, "An error occurred while retrieving the list: "));
                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<AnimalDiagnosticDto>>(true, "Entities retrieved successfully", animals));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
    }
}
