using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interface
{
    public interface ICategoryMedicinesController
    {
        Task<ActionResult<CategoryMedicinesDto>> GetById(int id);
        Task<ActionResult<CategoryMedicinesDto>> Save([FromBody] CategoryMedicinesDto entity);
        Task<IActionResult> Update(int id, [FromBody] CategoryMedicinesDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<IEnumerable<CategoryMedicinesDto>>> GetAll();

    }
}
