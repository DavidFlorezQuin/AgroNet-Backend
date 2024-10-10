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
        [HttpGet("datatable/{IdFarm}")]
        public async Task<ActionResult<List<AnimalDiagnosticDto>>> GetAnimalDiag(int IdFarm)
        {
            try
            {
                var animals = await _Data.GetAnimalDiagAsync(IdFarm);

                // Verificar si la lista está vacía
                if (animals == null || animals.Count == 0)
                {
                    return Ok(new ApiResponse<List<AnimalDiagnosticDto>>(true, "No alerts found for the specified farm.", new List<AnimalDiagnosticDto>()));

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
