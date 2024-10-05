﻿using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IProductionsBusiness : IBusiness<ProductionDto>
    {
        Task<ProductionDto> Save(ProductionDto dto);
        Task<IEnumerable<ProductionDto>> GetProductionAnimal(int IdAnimal); 
    }
}
