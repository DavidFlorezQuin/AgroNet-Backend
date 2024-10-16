﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class SuppliesDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string InputType { get; set; }
    }
}
