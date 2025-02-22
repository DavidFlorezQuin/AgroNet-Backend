﻿using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class SaleDto : BaseDto
    {
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Measurement { get; set; }
        public int ProductionId { get; set; }
        public string? Production { get; set; }
        public string? Animal { get; set; }

        public string Currency { get; set; }

    }
}
