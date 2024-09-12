using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class FarmDto : BaseDto
    {
        public string name { get; set; }
        public int dimension { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
    }
}
