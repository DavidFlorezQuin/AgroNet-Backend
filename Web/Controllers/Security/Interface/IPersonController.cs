using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    public interface IPersonController
    {
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<PersonDto>> Save([FromBody] PersonDto dto);
        Task<IActionResult> Update(int id, [FromBody] PersonDto dto);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();

    }
}
