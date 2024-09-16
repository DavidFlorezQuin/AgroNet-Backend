using Business.Parameter.Interface;
using Business.Parameter.services;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Service
{
    [ApiController]
    [Route("[controller]")]
    public class MedicinesController : ControllerBase
    {
        private IMedicinesBusiness _medicinesBusiness;

        public MedicinesController(IMedicinesBusiness medicinesBusiness)
        {
            _medicinesBusiness = medicinesBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicinesDto>> GetById(int id)
        {
            var result = await _medicinesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MedicinesDto>> Save([FromBody] MedicinesDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _medicinesBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicinesBusiness.Delete(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<MedicinesDto>>> GetAll()
        {
            var result = await _medicinesBusiness.GetAll();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MedicinesDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _medicinesBusiness.Update(id, entity);
            return NoContent();
        }


    }
}
