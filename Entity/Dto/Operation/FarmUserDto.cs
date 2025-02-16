using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class FarmUserDto : BaseDto
    {
        public int FarmsId { get; set; }
        public int UsersId { get; set; }
        public string? Farm { get; set; }
        public string? Users { get; set; }
        public bool IsOwner { get; set; }

    }
}
