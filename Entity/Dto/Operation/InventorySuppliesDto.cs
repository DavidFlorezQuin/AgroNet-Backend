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
        public DateTime date { get; set; }
        public int amount { get; set; }
        public int InventoryId { get; set; }
        public int SuppliesId { get; set; }

    }
}
