using Business.Operational.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [ApiController]
    [Route("api/[controller]")]

    public abstract class BaseController<TEntityDto, TBusiness> : ControllerBase
        where TEntityDto : class
        where TBusiness : IBusiness<TEntityDto>
    {
        private readonly TBusiness _business;

        protected BaseController(TBusiness business)
        {
            _business = business;
        }

        private int GetEntityId(TEntityDto entity)
        {
            var property = typeof(TEntityDto).GetProperty("Id");
            if (property == null)
            {
                throw new InvalidOperationException("Entity does not have an Id property.");
            }
            return (int)property.GetValue(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntityDto>> GetById(int id)
        {
            var result = await _business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<TEntityDto>>> GetAll()
        {
            var result = await _business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<TEntityDto>> Save([FromBody] TEntityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _business.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(result) }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TEntityDto entity)
        {
            if (entity == null || id != GetEntityId(entity))
            {
                return BadRequest();
            }
            await _business.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _business.Delete(id);
            return NoContent();
        }
    }
}
