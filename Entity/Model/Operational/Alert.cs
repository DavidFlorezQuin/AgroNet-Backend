﻿using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Alert : ABaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Boolean IsRead { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int CategoryAlertId { get; set; }

        public CategoryAlert CategoryAlert {  get; set; }
    }
}
