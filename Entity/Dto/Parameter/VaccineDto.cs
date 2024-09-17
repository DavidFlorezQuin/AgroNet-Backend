using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class VaccineDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DosesRequired { get; set; }
        public int RefuerzoPeriod { get; set; }
        public string Contraindications { get; set; }
        public string TypeVaccine { get; set; }
    }
}
