using Entity.Dto.Parameter;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interface
{
    public interface ICategoryAlertController
    {
        Task<ActionResult<CategoryAlertDto>> GetById(int id);
        Task<ActionResult<CategoryAlertDto>> Save([FromBody] CategoryAlertDto entity);
        Task<IActionResult> Update(int id, [FromBody] CategoryAlertDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<CategoryAlertDto>>> GetAll(); 
    }
}
