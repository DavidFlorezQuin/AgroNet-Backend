using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interface
{
    public interface IRaceController
    {
        Task<ActionResult<RaceDto>> GetById(int id);
        Task<ActionResult<RaceDto>> Save([FromBody] RaceDto entity);
        Task<IActionResult> Update(int id, [FromBody] RaceDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<RaceDto>>> GetAll();

    }
}
