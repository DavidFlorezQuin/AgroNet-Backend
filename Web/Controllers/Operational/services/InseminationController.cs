using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InseminationController : BaseController<InseminationDto, IInseminationBusiness>
    {
        private readonly IInseminationData _data; 

        private readonly IInseminationBusiness _inseminationBusiness;
        public InseminationController(IInseminationBusiness inseminationBusiness, IInseminationData data) : base(inseminationBusiness)
        {
            _data = data; 
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


        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<InseminationDto>>> GetAlerts(int farmId)
        {
            try
            {
                var insemination = await _data.GetInseminationAsync(farmId);

                // Verificar si la lista está vacía
                if (insemination == null || insemination.Count == 0)
                {
                    return Ok(new ApiResponse<List<InseminationDto>>(true, "No alerts found for the specified farm.", new List<InseminationDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<InseminationDto>>(true, "Entities retrieved successfully", insemination));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }
    }
}
