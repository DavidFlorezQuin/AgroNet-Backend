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
        [HttpPut("{inseminationId}/abortion")]
        public IActionResult RegisterAbortion(int inseminationId)
        {
            try
            {
                _data.RegisterAbortion(inseminationId);
                return Ok(new ApiResponse<bool>(true, "Aborto registrado exitosamente."));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message));
            }

        }
    }
}

