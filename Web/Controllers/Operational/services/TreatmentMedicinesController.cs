using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class TreatmentMedicinesController : BaseController<TreatmentMedicineDto, ITreatmentsMedicinesBusiness>
    {

        private readonly ITreatmentsMedicinesData _data; 
        private readonly ITreatmentsMedicinesBusiness _business; 
        public TreatmentMedicinesController(ITreatmentsMedicinesBusiness treatmentsMedicinesBusiness, ITreatmentsMedicinesData data) : base(treatmentsMedicinesBusiness) {

            _data = data;
            _business = treatmentsMedicinesBusiness; 

        }

        [HttpGet("datatable/{farmId}")]
        public async Task<ActionResult<List<TreatmentMedicineDto>>> GetTreatmentAsync(int farmId)
        {
            try
            {
                var treatments = await _data.GetTreatmentMedicineAsync(farmId);

                // Verificar si la lista está vacía
                if (treatments == null || treatments.Count == 0)
                {
                    return Ok(new ApiResponse<List<TreatmentMedicineDto>>(true, "No alerts found for the specified farm.", new List<TreatmentMedicineDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<TreatmentMedicineDto>>(true, "Entities retrieved successfully", treatments));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

        [HttpGet("GetMedicineForTreatments/{treatmentId}")]
        public async Task<ActionResult<List<TreatmentMedicineDto>>> GetMedicineForTreatments(int treatmentId)
        {
            try
            {
                var medicine = await _business.GetMedicineForTreatments(treatmentId);

                if (medicine == null || medicine.Count == 0)
                {
                    return Ok(new ApiResponse<List<TreatmentMedicineDto>>(true, "No alerts found for the specified farm.", new List<TreatmentMedicineDto>()));

                }

                // Devolver la lista de alertas
                return Ok(new ApiResponse<List<TreatmentMedicineDto>>(true, "Entities retrieved successfully", medicine));
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, $"Error al obtener las alertas: {ex.Message}");
            }
        }

    }
}
