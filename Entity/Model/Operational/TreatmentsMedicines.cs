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
        public int Periocity { get; set; }

        public int MedicinesId { get; set; }

        public Medicines Medicines { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
