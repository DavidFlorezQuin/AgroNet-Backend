using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;

namespace Entity.Model.Operational
{
    public class InventorySupplies : ABaseModel
    {
        public int Amount { get; set; }
        public string Measure {  get; set; }
        public int InventoryId { get; set; }
        public Inventories Inventory { get; set; }
        public int SuppliesId { get; set; }
        public Supplies Supplies { get; set; }
    }
}
