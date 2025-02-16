using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface ISaleData : IData<Sales>
    {

        Task<List<SaleDto>> GetSaleAsync(int farmId);
        Task<Sales> SaveAsync(Sales entity);
        Task UpdateProductionAsync(Productions productions);
        Task<Productions> GetProductionsAsync(int productionId);
        Task<List<DataProductionDto>> GetMonthlySale(int farmId);


    }
}
