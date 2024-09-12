using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Localitation.Interface
{
    public interface ICityController
    {
        Task<ActionResult<CityDto>> GetById(int id);
        Task<ActionResult<CityDto>> Save([FromBody] CityDto entity);
        Task<IActionResult> Update(int id, [FromBody] CityDto entity);
        Task<IActionResult> Delete(int id);
    }
}
