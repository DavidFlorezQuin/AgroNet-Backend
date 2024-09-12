using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventoryHistoryDto : BaseDto
    {
        public DateTime date { get; set; }
        public string amount { get; set; }
        public int InventoryId { get; set; }

    }
}
