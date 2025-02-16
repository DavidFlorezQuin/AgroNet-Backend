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

        private readonly IInseminationBusiness _inseminationBusiness;
        public InseminationController(IInseminationBusiness inseminationBusiness) : base(inseminationBusiness)
        {
            _inseminationBusiness = inseminationBusiness;
        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<InseminationDto>>> GetInseminationAsync(int farmId)
        {
            try
            {
                var insemination = await _inseminationBusiness.GetInseminationAsync(farmId);

                if (insemination == null || insemination.Count == 0)
                {
                    return Ok(new ApiResponse<List<InseminationDto>>(true, "No alerts found for the specified farm.", new List<InseminationDto>()));
                }

                return Ok(new ApiResponse<List<InseminationDto>>(true, "Entities retrieved successfully", insemination));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }        

            [HttpGet("active/{farmId}")]
            public async Task<ActionResult<List<InseminationDto>>> GetInseminationActive(int farmId)
            {
                try
                {
                    var insemination = await _inseminationBusiness.GetInseminationActive(farmId);

                    if (insemination == null || insemination.Count == 0)
                    {
                        return Ok(new ApiResponse<List<InseminationDto>>(true, "No alerts found for the specified farm.", new List<InseminationDto>()));
                    }

                    return Ok(new ApiResponse<List<InseminationDto>>(true, "Entities retrieved successfully", insemination));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
                }
            }

        [HttpPut("{inseminationId}/abortion")]
        public IActionResult RegisterAbortion(int inseminationId)
        {
            try
            {
                _inseminationBusiness.RegisterAbortion(inseminationId);
                return Ok(new ApiResponse<bool>(true, "Aborto registrado exitosamente."));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message));
            }

        }
        [HttpPut("{inseminationId}/born")]
        public IActionResult RegisterBorn(int inseminationId)
        {
            try
            {
                _inseminationBusiness.RegisterBorn(inseminationId);
                return Ok(new ApiResponse<bool>(true, "Aborto registrado exitosamente."));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<bool>(false, ex.Message));
            }

        }

    }
}

