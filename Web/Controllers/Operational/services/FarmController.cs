﻿using Business.Operational.Interface;
using Business.Operational.services;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class FarmController : BaseController<FarmDto, IFarmBusiness>
    {
        private readonly IFarmData _farmData;
        private readonly IFarmBusiness _farmBusiness;
        public FarmController(IFarmBusiness farmBusiness, IFarmData data) : base(farmBusiness)
        {
            _farmBusiness = farmBusiness;
            _farmData = data;
        }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<FarmDto>>> GetAlerts(int userId)
        {
            try
            {
                var farm = await _farmData.GetFarmAsync(userId);

                // Verificar si la lista está vacía
                if (farm == null || farm.Count == 0)
                {
                    return Ok(new ApiResponse<List<FarmDto>>(true, "No alerts found for the specified farm.", new List<FarmDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<FarmDto>>(true, "Entities retrieved successfully", farm));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

        [HttpPost("saveAsync")]
        public async Task<ActionResult<FarmDto>> SaveAsync([FromBody] FarmUserBodyDto farmUserBodyDto)
        {
            try
            {
                if (farmUserBodyDto == null)
                {
                    return BadRequest(new ApiResponse<FarmDto>(false, "Entity is null"));

                }
                var farms = await _farmBusiness.SaveAsync(farmUserBodyDto);
                return Ok(new ApiResponse<FarmDto>(true, "Entity created successfully", farms));

            }catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  new ApiResponse<FarmDto>(false, "An unexpected error occurred: " + ex.Message));
            
        }
    }

}
}
