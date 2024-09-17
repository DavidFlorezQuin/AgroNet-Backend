using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class VaccineAnimalDto :BaseDto
    {
        public int AnimalId { get; set; }
        public int VaccineId { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime NextDose { get; set; }
    }
}
