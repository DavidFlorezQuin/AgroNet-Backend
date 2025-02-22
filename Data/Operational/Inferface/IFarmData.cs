﻿using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IFarmData : IData<Farms>
    {
        Task<List<FarmDto>> GetFarmAsync(int farmId);
        Task<Farms> SaveAsync(Farms farms, int userId);
        Task<Farms> SearchFarmByCode(string codeFarm);
    }
}
