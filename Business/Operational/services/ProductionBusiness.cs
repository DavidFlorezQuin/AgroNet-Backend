﻿using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services 
{
    public class ProductionBusiness : BaseBusiness<Productions, ProductionDto>, IProductionsBusiness
    {
        private readonly IProductionsData _dataProduction;
        public ProductionBusiness(IMapper mapper, IProductionsData data) : base(mapper, data)
        {
            _dataProduction = data;
        }

        public override async Task<ProductionDto> Save(ProductionDto dto)
        {
            var entity = _mapper.Map<Productions>(dto);
            entity.created_at = DateTime.UtcNow;

            bool isMale = await _dataProduction.ValidProduction(entity);

            if (isMale)
            {
                throw new InvalidOperationException("Al animal no se le puede registrar esta producción");
            }

            await _data.Save(entity);

            return _mapper.Map<ProductionDto>(entity);
        }

        public async Task<List<DataProductionDto>> GetMonthlyMilkProductionAsync(int farmId) 
        {
            return await _dataProduction.GetMonthlyMilkProductionAsync(farmId); 
        }



    }

}
