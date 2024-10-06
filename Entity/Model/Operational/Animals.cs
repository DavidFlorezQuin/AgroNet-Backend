using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Animals : ABaseModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string Photo { get; set; }

        public string Race { get; set; }
        public string purpose { get; set; }
        public DateTime birthDay { get; set; }
        public int LotId { get; set; }
        public Lots Lot { get; set; }

    }
}
