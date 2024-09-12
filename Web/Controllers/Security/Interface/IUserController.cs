using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    public interface IUserController
    {
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserDto entity);
        Task<IActionResult> Delete(int id);
    }
}
