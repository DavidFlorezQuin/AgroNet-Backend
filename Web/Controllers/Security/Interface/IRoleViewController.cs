using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    public interface IRoleViewController
    {
        Task<ActionResult<RoleViewDto>> GetById(int id);
        Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto dto);
        Task<IActionResult> Update(int id, [FromBody] RoleViewDto dto);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
    }
}
