using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventoryDto : BaseDto
    {
        public DateTime admission_date { get; set; }
        public int stock { get; set; }
        public DateTime expirationDate { get; set; }
        public int SuppliesId { get; set; }
    }
}
