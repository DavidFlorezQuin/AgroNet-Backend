using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class ProductionDto : BaseDto
    {
        public DateTime date { get; set; }
        public string TypeProduction { get; set; }
        public double Quantity { get; set; }
        public string Measurement { get; set; }
        public string Observation { get; set; }
        public double QuantityTotal { get; set; }
        public DateTime ExpirateDate { get; set; }
        public int AnimalId { get; set; }
    }
}
