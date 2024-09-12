using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class MedicinesDto
    {
        public string Name { get; set; }
        public string MedicationAdministration { get; set; }
        public string UnitMeasure { get; set; }
        public int TypeMedicinesId { get; set; }
    }
}
