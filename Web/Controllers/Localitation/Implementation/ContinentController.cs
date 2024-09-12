using Business.Localitation.Interface;
using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Localitation.Implementation
{
    [ApiController]
    [Route("[controller]")]
    public class ContinentController : ControllerBase
    {

        private readonly IContinentBusiness _continentBusiness;

        public ContinentController(IContinentBusiness continentBusiness)
        {
            _continentBusiness = continentBusiness;
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ContinentDto>>> GetAll()
        {
            var result = await _continentBusiness.GetAll();

            if(result == null)
            {
                NotFound(); 
            }

            return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContinentDto>> GetById(int id)
        {
            var result = await _continentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _continentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContinentDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _continentBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _continentBusiness.Delete(id);
            return NoContent();
        }
    }
}

