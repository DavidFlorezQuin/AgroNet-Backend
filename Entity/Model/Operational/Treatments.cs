using Entity.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Treatments : ABaseModel
    {
        public string Description { get; set; }
        public DateTime FinishiedDate { get; set;}
        public DateTime StartDate { get; set;}
        public int AnimalDiagnosticsId { get; set;}
        public AnimalDiagnostics AnimalDiagnostics { get; set; }
        public string Name { get; set; }

    }
}
