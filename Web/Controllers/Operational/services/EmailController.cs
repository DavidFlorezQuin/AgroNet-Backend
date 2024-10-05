using Business.Utilities.Interface;
using Entity.Dto.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISentEmailPassword _sentEmailPassword;
        public EmailController(ISentEmailPassword sentEmailPassword)
        {
            _sentEmailPassword = sentEmailPassword;
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _sentEmailPassword.SendPasswordResetLink(model.Email);
                return Ok(new { Message = "Password reset link sent to your email." });

            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra algún problema
                return BadRequest(new { Message = ex.Message });
            }

        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _sentEmailPassword.ResetPassword(model.Token, model.NewPassword);
                return Ok(new { Message = "Password has been reset successfully." });
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de token inválido o expirado
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
