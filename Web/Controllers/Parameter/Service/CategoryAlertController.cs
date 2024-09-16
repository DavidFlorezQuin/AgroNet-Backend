using Business.Parameter.Interface;
using Business.Parameter.services;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Service
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryAlertController : ControllerBase
    {
        private ICategoryAlertBusiness _categoryAlertBusiness;

        public CategoryAlertController(ICategoryAlertBusiness categoryAlertBusiness)
        {
            _categoryAlertBusiness = categoryAlertBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryAlertDto>> GetById(int id)
        {
            var result = await _categoryAlertBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RaceDto>> Save([FromBody] CategoryAlertDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _categoryAlertBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAlertBusiness.Delete(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CategoryAlertDto>>> GetAll()
        {
            var result = await _categoryAlertBusiness.GetAll();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryAlertDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _categoryAlertBusiness.Update(id, entity);
            return NoContent();
        }
    }
}
