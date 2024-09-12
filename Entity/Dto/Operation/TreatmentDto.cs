using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class TreatmentDto : BaseDto
    {
        public string medicines { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public int HealthHistoryId { get; set; }

    }
}
