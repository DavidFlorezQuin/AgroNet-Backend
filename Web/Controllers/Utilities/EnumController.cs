using Entity.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Utilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDocumentTypes()
        {
            // Obtiene los nombres de los valores del enum y los devuelve en una lista
            var enumValues = Enum.GetNames(typeof(ETypeDocument)).ToList();
            return Ok(enumValues);
        }
    }
}
