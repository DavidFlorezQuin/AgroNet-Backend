using Business.Security.Implementation;
using Business.Security.Interfaces;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements.Security
{
    [ApiController]
    [Route("[controller]")]
    public class RoleViewController : ControllerBase
    {

        private readonly IRoleViewBusiness _roleViewBusiness;

        public RoleViewController(IRoleViewBusiness roleViewBusiness)
        {
            _roleViewBusiness = roleViewBusiness;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _roleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _roleViewBusiness.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleViewBusiness.Save(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleViewDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest();
            }
            await _roleViewBusiness.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleViewBusiness.Delete(id);
            return NoContent();
        }
    }
}
