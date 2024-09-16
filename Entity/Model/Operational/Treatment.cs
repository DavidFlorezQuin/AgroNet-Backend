using Entity.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Treatment : ABaseModel
    {
        public string Name { get; set; }
        public string description { get; set; }
        public DateTime finished_date { get; set;}
        public DateTime start_date { get; set;}
        public int HealthId {get; set;}
        public Health Health { get; set; }

    }
}
