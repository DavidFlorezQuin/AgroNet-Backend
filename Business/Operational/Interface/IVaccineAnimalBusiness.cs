﻿using Entity.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IVaccineAnimalBusiness : IBusiness<VaccineAnimalDto>
    {
        Task<VaccineAnimalDto> Save(VaccineAnimalDto dto);

    }
}
