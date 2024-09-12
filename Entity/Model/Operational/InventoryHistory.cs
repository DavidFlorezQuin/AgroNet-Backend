using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class InventoryHistory : ABaseModel
    {
        public DateTime date { get; set; }
        public int amount { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }


    }
}
