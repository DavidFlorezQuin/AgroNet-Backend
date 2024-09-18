using Business.Security.Implementation;
using Business.Security.Interfaces;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {


        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var result = await _roleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _roleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleBusiness.Delete(id);
            return NoContent();
        }


        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var result = await _roleBusiness.GetAll();
            return Ok(result);
        }


        [HttpGet("UserRole/{id}")]
        public async Task<ActionResult<IEnumerable<ViewDto>>> ViewsByRole(int id)
        {
            var result = await _roleBusiness.ViewsByRole(id);
            return Ok(result);
        }


    }
}
