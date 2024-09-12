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
        public string medicines { get; set; }
        public string description { get; set; }
        public DateTime date { get; set;}

        public int HealthHistoryId {get; set;}
        public HealthHistory HealthHistory { get; set; }

    }
}
