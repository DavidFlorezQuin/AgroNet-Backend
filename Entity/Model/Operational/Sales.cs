using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Sales : ABaseModel
    {

        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Measurement { get; set; }
        public int ProductionId { get; set; }
        public Productions? Production { get; set; }
        public Animals? Animal { get; set; }
        public string Currency { get; set; }
    }
}
