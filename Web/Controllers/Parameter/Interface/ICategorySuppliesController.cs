using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interface
{
    public interface ICategorySuppliesController
    {
        Task<ActionResult<CategorySuppliesDto>> GetById(int id);
        Task<ActionResult<CategorySuppliesDto>> Save([FromBody] CategorySuppliesDto entity);
        Task<IActionResult> Update(int id, [FromBody] CategorySuppliesDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<CategorySuppliesDto>>> GetAll();

    }
}
