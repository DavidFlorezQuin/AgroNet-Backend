﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Supplies : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CategorySuppliesId { get; set; }
        public CategorySupplies CategorySupplies { get; set; }

    }
}
