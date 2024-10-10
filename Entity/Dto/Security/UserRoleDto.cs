using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class UserRoleDto : BaseDto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 

        public int RoleId { get; set; }

        public int UserId { get; set; }

    }
}
