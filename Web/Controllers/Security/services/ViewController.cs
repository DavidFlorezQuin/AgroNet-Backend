    using Business.Security.Interfaces;
    using Entity.Dto.Security;
    using Microsoft.AspNetCore.Mvc;

    namespace Web.Controllers.Implements.Security
    {

        [ApiController]
        [Route("api/[controller]")]
        public class ViewController : ControllerBase
        {

            private readonly IViewBusiness _viewBusiness;

            public ViewController(IViewBusiness viewBusiness)
            {
                _viewBusiness = viewBusiness;
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<ViewDto>> GetById(int id)
            {
                var result = await _viewBusiness.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
            {
                if (entity == null)
                {
                    return BadRequest("Entity is null");
                }
                var result = await _viewBusiness.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ViewDto entity)
            {
                if (entity == null || id != entity.Id)
                {
                    return BadRequest();
                }
                await _viewBusiness.Update(id, entity);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _viewBusiness.Delete(id);
                return NoContent();
            }

            [HttpGet("list")]
            public async Task<ActionResult<IEnumerable<ViewDto>>> GetAll()
            {
                var result = await _viewBusiness.GetAll();
                return Ok(result);
            }

            [HttpGet("byRole/{id}")]
            public async Task<ActionResult<IEnumerable<ViewDto>>> ViewsByRole(int id)
            {
                var result = await _viewBusiness.ViewsByRole(id);
                return Ok(result);
            }


        }
    }
