using Business.Security.Interfaces;
using Data.Security.Implementation;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;


        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("menu/{userId}")]
        public async Task<IActionResult> GetMenuForUser(int userId)
        {
            var menu = await _userBusiness.MapRolesToMenu(userId);
            return Ok(menu);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)

        {
            if (loginDto == null)
            {
                return BadRequest("Invalid client request");
            }

            var userDto = await _userBusiness.LoginAsync(loginDto);

            if (userDto == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(userDto);
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _userBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _userBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userBusiness.Delete(id);
            return NoContent();
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _userBusiness.GetAll();
            return Ok(result);
        }


    }
}
