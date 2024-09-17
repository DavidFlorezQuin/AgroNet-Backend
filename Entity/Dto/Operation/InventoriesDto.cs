using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InventoriesDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FarmId { get; set; }
    }
}
