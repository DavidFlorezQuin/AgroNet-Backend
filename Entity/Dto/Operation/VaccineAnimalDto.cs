using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class VaccineAnimalDto : BaseDto
    {
        public int AnimalId { get; set; } 
        public string? Animal { get; set; }
        public int VaccinesId { get; set; }
        public string? Vaccine { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime? NextDose { get; set; }
    }
}
