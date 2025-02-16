using Business.Exceptions;
using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class FarmUserController : BaseController<FarmUserDto, IFarmUserBusiness>
    {
        private readonly IFarmUserBusiness _business;
        public FarmUserController(IFarmUserBusiness farmUserBusiness) : base(farmUserBusiness)
        {
            _business = farmUserBusiness;
        }

        [HttpPost("join-farm")]
        public async Task<IActionResult> JoinFarm(string farmCode, int userId)
        {
            try
            {
                await _business.JoinFarm(farmCode, userId);
                return Ok(new ApiResponse<bool>(true, "Solicitud enviada"));

            }
            catch (ZeroException ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, ex.Message));

            }
            catch (FarmNotCodeExceptions ex)
            {
                return BadRequest(new ApiResponse<string>(false, ex.Message));

            }
            catch (UserFarmRelationAlreadyExistsException ex)
            {
                return Conflict(new ApiResponse<string>(false, ex.Message));

            }
            catch (Exception ex) 
            {
                return StatusCode(500, new ApiResponse<string>(false, "Error inesperado: " + ex.Message));
            }
        }
        [HttpPost("accept-user")]
        public async Task <IActionResult> AcceptUserFarm([FromBody] int userFarmId)
        {
            try
            {
                await _business.AcceptUserFarm(userFarmId);
                return Ok(new ApiResponse<bool>(true, "Usuario aceptado a la finca"));
            }
            catch (ZeroException ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, ex.Message));
            }
            catch (FarmNotCodeExceptions ex)
            {
                return BadRequest(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpGet("list-join-users/{idUser}")]
        public async Task<ActionResult<List<FarmUserDto>>> GetRequestUsers(int idUser)
        {
            try
            {
                var users = await _business.GetRequestUsers(idUser);
                return Ok(new ApiResponse<List<FarmUserDto>>(true, "Datos registrados", users)); 
            }catch(ZeroException ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, ex.Message));
            }catch(NoRequestUsersException ex)
            {
                return NotFound(new ApiResponse<string>(false, ex.Message));
            }
        }
    }
}
