using Entity.Model.Operational;
using Entity.Model.Security;
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
        public string Administration { get; set; }
        public int CategoryMedicinesId { get; set; }
        public string Description { get; set; }
        public CategoryMedicines? CategoryMedicines { get; set; }

    }
}
