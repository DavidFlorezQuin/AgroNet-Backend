using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventoryRecordsDto : BaseDto
    {
        public int Amount { get; set; }
        public double Measure { get; set; }
        public string TransactionType { get; set; }
        public int UsersId { get; set; }
        public string? Users { get; set; }
        public int InventorySuppliesId { get; set; }
    }
}
