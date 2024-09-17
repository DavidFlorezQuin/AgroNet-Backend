using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class LotsDto : BaseDto
    {
        public string Name { get; set; }
        public double Hectare { get; set; }
        public int FarmId { get; set; }

    }
}
