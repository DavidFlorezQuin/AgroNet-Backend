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
        public string Description { get; set; }
        public DateTime FinishiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public int AnimalDiagnosticsId { get; set; }

    }
}
