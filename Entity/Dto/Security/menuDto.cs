using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class menuDto
    {
        public UserDto User { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<ViewDto> Views { get; set; }
    }
}
