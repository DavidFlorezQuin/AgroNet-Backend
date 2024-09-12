using Business.Localitation.Interface;
using Business.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Localitation.Implementation
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {

        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _cityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _cityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _cityBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityBusiness.Delete(id);
            return NoContent();
        }
    }
}
