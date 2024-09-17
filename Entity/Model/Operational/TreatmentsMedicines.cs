using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class TreatmentsMedicines : ABaseModel
    {
        public string Description { get; set; }
        public int PeriocityDay { get; set; }

        public int MedicinesId { get; set; }

        public Medicines Medicines { get; set; }
        public int TreatmentId { get; set; }
        public Treatments Treatment { get; set; }
    }
}
