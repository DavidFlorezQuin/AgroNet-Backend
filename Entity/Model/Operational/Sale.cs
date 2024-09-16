using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Sale : ABaseModel
    {
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public double Quantity { get; set; }
        public string Measurement { get; set; }
        public int ProductionId { get; set; }
        public Production Production { get; set; }
        public string Currency {  get; set; }

    }
}
