﻿using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IBirthData : IData<Births>
    {
        Task<List<BirthDto>> GetBirthAsync(int idFarm); 
    }
}
