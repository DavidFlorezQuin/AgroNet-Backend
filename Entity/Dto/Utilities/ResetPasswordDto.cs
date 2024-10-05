using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Utilities
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener 6 carácteres")]
        public string NewPassword { get; set; }
    }
}
