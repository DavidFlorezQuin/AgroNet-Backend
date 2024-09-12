using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class RoleMenuDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<ModuloDto> Modulo { get; set; }
    }
}
