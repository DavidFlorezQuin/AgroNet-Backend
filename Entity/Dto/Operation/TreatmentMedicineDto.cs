using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class TreatmentMedicineDto : BaseDto
    {
        public string Description { get; set; }
        public int PeriocityDay { get; set; }
        public int MedicinesId { get; set; }
        public string? Medicines { get; set; }
        public int TreatmentId { get; set; }
        public string? Treatment { get; set; }
    }
}
