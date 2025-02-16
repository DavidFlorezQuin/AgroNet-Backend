using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class MedicinesDto : BaseDto
    {
        public string Name { get; set; }
        public string Administration { get; set; }
        public string Description { get; set; }
        public int CategoryMedicinesId { get; set; }
        public string? CategoryMedicines { get; set; }

    }
}
