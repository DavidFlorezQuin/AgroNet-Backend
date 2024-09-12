using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Localitation.Interface
{
    public interface ICountryController
    {
        Task<ActionResult<CountryDto>> GetById(int id);
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity);
        Task<IActionResult> Update(int id, [FromBody] CountryDto entity);
        Task<IActionResult> Delete(int id);

    }
}
