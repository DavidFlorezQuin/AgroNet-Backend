using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class ProductionDto : BaseDto
    {
        public string typeProduction { get; set; }
        public double quantity { get; set; }
        public string measurement { get; set; }
        public string observation { get; set; }
    }
}
