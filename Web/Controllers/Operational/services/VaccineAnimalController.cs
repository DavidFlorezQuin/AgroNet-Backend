using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class VaccineAnimalController : BaseController<VaccineAnimalDto, IVaccineAnimalBusiness>
    {

        private readonly IVaccineAnimalData _data; 
        public VaccineAnimalController(IVaccineAnimalBusiness vaccineAnimalBusiness, IVaccineAnimalData data) : base(vaccineAnimalBusiness) {
            _data = data; 
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<VaccineAnimalDto>>> GetTreatmentAsync(int farmId)
        {
            try
            {
                var vaccineAnimal = await _data.GetVaccineAnimalAsync(farmId);

                // Verificar si la lista está vacía
                if (vaccineAnimal == null || vaccineAnimal.Count == 0)
                {
                    return Ok(new ApiResponse<List<VaccineAnimalDto>>(true, "No alerts found for the specified farm.", new List<VaccineAnimalDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<VaccineAnimalDto>>(true, "Entities retrieved successfully", vaccineAnimal));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
    }
}
