using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Productions : ABaseModel
    {
        public string TypeProduction { get; set; }
        public double Stock { get; set; }
        public string Measurement { get; set; }
        public string Description { get; set; }
        public double QuantityTotal { get; set; }
        public DateTime? ExpirateDate { get; set; }
        public int AnimalId { get; set; }
        public Animals Animal { get; set; }
    }
}
