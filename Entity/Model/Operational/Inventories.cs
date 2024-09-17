using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Inventories : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FarmId { get; set; }
        public Farms Farm { get; set; }
    }
}
