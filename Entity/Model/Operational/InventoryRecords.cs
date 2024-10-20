using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class InventoryRecords  : ABaseModel
    {
        public int Amount {  get; set; }
        public string Measure { get; set; }
        public string TransactionType { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int InventorySuppliesId { get; set; }
        public InventorySupplies InventorySupplies { get; set; }
    }
}
