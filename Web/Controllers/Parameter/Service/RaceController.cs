using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Service
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : ControllerBase
    {
        private IRaceBusiness _raceBusiness;

        public RaceController(IRaceBusiness raceBusiness)
        {
            _raceBusiness = raceBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceDto>> GetById(int id)
        {
            var result = await _raceBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RaceDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _raceBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RaceDto>> Save([FromBody] RaceDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _raceBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _raceBusiness.Detele(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<RaceDto>>> GetAll()
        {
            var result = await _raceBusiness.GetAll();
            return Ok(result);
        }


    }
}
