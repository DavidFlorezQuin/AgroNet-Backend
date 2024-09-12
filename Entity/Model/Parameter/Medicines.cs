using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Medicines : ABaseModel
    {
        public string Name { get; set; }
        public string MedicationAdministration { get; set; }
        public string UnitMeasure { get; set; }
        public CategoryMedicines TypeMedicinesId { get; set; }

    }
}
