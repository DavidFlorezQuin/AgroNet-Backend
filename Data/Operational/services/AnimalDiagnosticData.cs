﻿using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class AnimalDiagnosticData : ABaseData<AnimalDiagnostics>, IAnimalDiagnosticData
    {
        public AnimalDiagnosticData(AplicationDbContext context) : base(context) { }

    }
}
