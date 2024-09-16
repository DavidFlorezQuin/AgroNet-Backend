using Business.Parameter.Interface;
using Business.Parameter.services;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Service
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryMedicinesController : ControllerBase
    {
        private ICategoryMedicinesBusiness _categoryMedicinesBusiness;

        public CategoryMedicinesController(ICategoryMedicinesBusiness categoryMedicinesBusiness)
        {
            _categoryMedicinesBusiness = categoryMedicinesBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryMedicinesDto>> GetById(int id)
        {
            var result = await _categoryMedicinesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryMedicinesDto>> Save([FromBody] CategoryMedicinesDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _categoryMedicinesBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryMedicinesBusiness.Delete(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CategoryMedicinesDto>>> GetAll()
        {
            var result = await _categoryMedicinesBusiness.GetAll();
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryMedicinesDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _categoryMedicinesBusiness.Update(id, entity);
            return NoContent();
        }
    }
}
