using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Inventory : ABaseModel
    {
        public DateTime AdmissionDate { get; set; }
        public string Name { get; set; }

        public DateTime expiration_date { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }
    }
}
