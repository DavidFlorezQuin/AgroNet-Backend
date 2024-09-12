using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    public interface IViewController
    {
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity);
        Task<IActionResult> Update(int id, [FromBody] ViewDto entity);
        Task<IActionResult> Delete(int id);
    }
}
