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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Finished_date { get; set; }
        public DateTime Start_date { get; set; }
        public int HealthId { get; set; }

    }
}
