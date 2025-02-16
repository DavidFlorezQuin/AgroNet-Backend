using AutoMapper;
using Business.Exceptions;
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
    public class SalesBusiness : BaseBusiness<Sales, SaleDto>, ISaleBusiness
    {
        private readonly ISaleData _saleData;

        public SalesBusiness(IMapper mapper, ISaleData data) : base(mapper, data)
        {

            _saleData = data;
        }

        public async Task<SaleDto> SaveAsync(SaleDto saleDto)
        {
            var production = await _saleData.GetProductionsAsync(saleDto.ProductionId);
            if (production == null)
            {
                throw new ProductionNotFoundException();
            }
            if (production.Stock < saleDto.Quantity)
            {
                throw new InsufficientStockException();
            }

            AjustProductionStock(production, saleDto.Quantity);

            await _saleData.UpdateProductionAsync(production);

            var entity = _mapper.Map<Sales>(saleDto);
            var savedEntity = await _saleData.SaveAsync(entity);
            return _mapper.Map<SaleDto>(savedEntity);

        }

        private void AjustProductionStock(Productions  productions, double quantity)
        {
            if(productions.TypeProduction == "LECHE")
            {
                productions.Stock -= quantity;

                if (productions.Stock == 0)
                    productions.state = false; 
            }

        }

        public async Task<List<DataProductionDto>> GetSaleAsync(int farmId){
            return await _saleData.GetMonthlySale(farmId);
        }

    }
}
