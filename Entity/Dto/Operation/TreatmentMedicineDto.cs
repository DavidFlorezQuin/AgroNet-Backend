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
        public int Periocity { get; set; }
        public int MedicinesId { get; set; }
        public int TreatmentId { get; set; }
    }
}
