using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class UserFarmsDto : BaseDto
    {
        public int UsersId { get; set; }
        public int FarmId { get; set; }
    }
}
