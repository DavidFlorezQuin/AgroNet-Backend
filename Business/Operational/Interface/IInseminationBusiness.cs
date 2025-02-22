﻿using Entity.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IInseminationBusiness : IBusiness<InseminationDto>
    {
        Task<InseminationDto> Save(InseminationDto dto);
        public void RegisterAbortion(int inseminationId);
        public void RegisterBorn(int inseminationId);
        Task<List<InseminationDto>> GetInseminationAsync(int farmId);
        Task<List<InseminationDto>> GetInseminationActive(int farmId);


    }
}
