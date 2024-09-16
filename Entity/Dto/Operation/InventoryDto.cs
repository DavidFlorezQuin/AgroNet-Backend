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
        public DateTime AdmissionDate { get; set; }
        public string Name { get; set; }
        public DateTime expiration_date { get; set; }
        public int FarmId { get; set; }
    }
}
