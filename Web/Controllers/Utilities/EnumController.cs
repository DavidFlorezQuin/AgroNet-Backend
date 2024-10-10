using Entity.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Utilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet("TypeDocument")]   
        public IActionResult GetDocumentTypes()
        {
            var enumValues = Enum.GetNames(typeof(ETypeDocument)).ToList();
            return Ok(enumValues);
        }        
        [HttpGet("Race")]
        public IActionResult GetRace()
        {
            var enumValues = Enum.GetNames(typeof(ERace)).ToList();
            return Ok(enumValues);
        }

        [HttpGet("Measurement")]
        public IActionResult GetMeasurement()
        {
            var enumValues = Enum.GetNames(typeof(EMeaserument)).ToList();
            return Ok(enumValues);
        }
    }
}
