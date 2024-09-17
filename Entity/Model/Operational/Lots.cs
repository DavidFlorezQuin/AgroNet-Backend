using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Lots : ABaseModel
    {
        public string Name { get; set; }
        public double Hectare { get; set; }
        public int FarmId { get; set; }
        public Farms Farm { get; set; }


    }
}
