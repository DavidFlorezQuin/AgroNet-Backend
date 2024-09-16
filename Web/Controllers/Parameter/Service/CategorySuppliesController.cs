using Business.Parameter.Interface;
using Business.Parameter.services;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Service
{
    [ApiController]
    [Route("[controller]")]
    public class CategorySuppliesController : ControllerBase
    {
        private ICategorySuppliesBusiness _categorySuppliesBusiness;

        public CategorySuppliesController(ICategorySuppliesBusiness categorySuppliesBusiness)
        {
            _categorySuppliesBusiness = categorySuppliesBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategorySuppliesDto>> GetById(int id)
        {
            var result = await _categorySuppliesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategorySuppliesDto>> Save([FromBody] CategorySuppliesDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _categorySuppliesBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categorySuppliesBusiness.Delete(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CategorySuppliesDto>>> GetAll()
        {
            var result = await _categorySuppliesBusiness.GetAll();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategorySuppliesDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _categorySuppliesBusiness.Update(id, entity);
            return NoContent();
        }

    }
}
