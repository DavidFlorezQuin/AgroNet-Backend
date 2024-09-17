using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class VaccineAnimals : ABaseModel
    {
        public int AnimalId { get; set; }
        public Animals Animal { get; set; }

        public int VaccineId { get; set; }
        public Vaccines Vaccines { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime NextDose { get; set; }
    }
}
