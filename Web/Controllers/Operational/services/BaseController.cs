using Business.Operational.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntityDto, TBusiness> : ControllerBase
        where TEntityDto : class
        where TBusiness : IBusiness<TEntityDto>
    {
        private readonly TBusiness _business;

        protected BaseController(TBusiness business)
        {
            _business = business;
        }

        private int GetEntityId(TEntityDto entity)
        {
            var property = typeof(TEntityDto).GetProperty("Id");
            if (property == null)
            {
                throw new InvalidOperationException("Entity does not have an Id property.");
            }
            return (int)property.GetValue(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<TEntityDto>>> GetById(int id)
        {
            try
            {
                var result = await _business.GetById(id);
                if (result == null)
                {
                    return NotFound(new ApiResponse<TEntityDto>(false, "Entity not found"));
                }
                return Ok(new ApiResponse<TEntityDto>(true, "Entity retrieved successfully", result));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<TEntityDto>(false, "An error occurred while retrieving the entity: " + e.Message));
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TEntityDto>>>> GetAll()
        {
            try
            {
                var result = await _business.GetAll();
                return Ok(new ApiResponse<IEnumerable<TEntityDto>>(true, "Entities retrieved successfully", result));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<IEnumerable<TEntityDto>>(false, "An error occurred while retrieving the list: " + e.Message));
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<ApiResponse<TEntityDto>>> Save([FromBody] TEntityDto entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest(new ApiResponse<TEntityDto>(false, "Entity is null"));
                }

                var result = await _business.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = GetEntityId(result) },
                    new ApiResponse<TEntityDto>(true, "Entity created successfully", result));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new ApiResponse<TEntityDto>(false, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<TEntityDto>(false, "An unexpected error occurred: " + e.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<TEntityDto>>> Update(int id, [FromBody] TEntityDto entity)
        {
            try
            {
                if (entity == null || id != GetEntityId(entity))
                {
                    return BadRequest(new ApiResponse<TEntityDto>(false, "Invalid entity or ID mismatch"));
                }

                await _business.Update(id, entity);
                return Ok(new ApiResponse<TEntityDto>(true, "Entity updated successfully"));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new ApiResponse<TEntityDto>(false, "Update operation failed: " + e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<TEntityDto>(false, "An error occurred while updating the entity: " + e.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<TEntityDto>>> Delete(int id)
        {
            try
            {
                await _business.Delete(id);
                return Ok(new ApiResponse<TEntityDto>(true, "Entity deleted successfully"));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new ApiResponse<TEntityDto>(false, "Delete operation failed: " + e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<TEntityDto>(false, "An error occurred while deleting the entity: " + e.Message));
            }
        }
    }
}
