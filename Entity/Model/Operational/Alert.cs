using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Alert : ABaseModel
    {
        public string name { get; set; }

        public string description { get; set; }
        public DateTime date { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
