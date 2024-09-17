using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventorySuppliesDto : BaseDto
    {
        public int Amount { get; set; }
        public string Measure { get; set; }
        public int InventoryId { get; set; }
        public int SuppliesId { get; set; }

    }
}
