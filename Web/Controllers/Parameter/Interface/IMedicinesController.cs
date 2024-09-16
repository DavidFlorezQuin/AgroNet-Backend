using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interface
{
    public interface IMedicinesController
    {
        Task<ActionResult<MedicinesDto>> GetById(int id);
        Task<ActionResult<MedicinesDto>> Save([FromBody] MedicinesDto entity);
        Task<IActionResult> Update(int id, [FromBody] MedicinesDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<MedicinesDto>>> GetAll();

    }
}
