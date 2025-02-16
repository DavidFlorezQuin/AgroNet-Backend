using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ISaleBusiness : IBusiness<SaleDto>
    {
        Task<SaleDto> SaveAsync(SaleDto saleDto);

        Task<List<DataProductionDto>> GetSaleAsync(int farmId);

    }
}
