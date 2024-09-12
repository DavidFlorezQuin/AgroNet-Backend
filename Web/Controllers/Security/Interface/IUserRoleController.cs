using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    public interface IUserRoleController
    {
        Task<ActionResult<UserRoleDto>> GetById(int id);
        Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserRoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
