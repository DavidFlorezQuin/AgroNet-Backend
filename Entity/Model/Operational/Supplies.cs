using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Supplies : ABaseModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public string input_type { get; set; }
        public DateTime date { get; set; }

    }
}
