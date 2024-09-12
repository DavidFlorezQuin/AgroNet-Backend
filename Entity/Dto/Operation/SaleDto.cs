using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class SaleDto : BaseDto
    {
        public double price { get; set; }
        public DateTime date { get; set; }
        public double quantity { get; set; }

        public int ProductionId { get; set; }

    }
}
