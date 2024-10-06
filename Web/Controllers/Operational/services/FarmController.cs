using Business.Operational.Interface;
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



        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<FarmDto>>>> GetFarmsByUser(int userId)
        {

            var farms = await _farmBusiness.MapFarmDto(userId);

            if (farms == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new ApiResponse<IEnumerable<FarmDto>>(false, "An error occurred while retrieving the list: "));
            }

            return Ok(new ApiResponse<IEnumerable<FarmDto>>(true, "Entities retrieved successfully", farms));

        }

        [HttpGet("datatable")]
        public async Task<ActionResult<List<FarmDto>>> GetAlerts(int userId)
        {
            try
            {
                var farm = await _farmData.GetFarmAsync(userId);

                // Verificar si la lista está vacía
                if (farm == null || farm.Count == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                                        new ApiResponse<List<FarmDto>>(false, "An error occurred while retrieving the list: "));
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

    }
}
