using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class MedicinesController : BaseController<MedicinesDto, IMedicinesBusiness>
    {
        private readonly IMedicinesBusiness _business;

        public MedicinesController(IMedicinesBusiness medicinesBusiness) : base(medicinesBusiness) { _business = medicinesBusiness;  }

        [HttpGet("datatable/{userId}")]
        public async Task<ActionResult<List<MedicinesDto>>> GetMedicinesAsync(int userId)
        {
            try
            {
                var obj = await _business.GetMedicineAsync(userId);
                return Ok(new ApiResponse<List<MedicinesDto>>(true, "Datos recuperados exitosamente", obj));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<List<MedicinesDto>>(false, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }
    }
}
