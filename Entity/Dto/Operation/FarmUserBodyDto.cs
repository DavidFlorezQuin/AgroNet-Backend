using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class FarmUserBodyDto
    {
        public FarmDto farmDto { get; set; }
        public int UserId { get; set; }
    }
}
