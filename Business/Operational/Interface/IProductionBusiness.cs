using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IProductionBusiness
    {
        Task Delete(int id);

        Task<Production> Save(ProductionDto dto);

        Task<ProductionDto> GetById(int id);

        Task Update(int id, ProductionDto dto);

        Task<IEnumerable<ProductionDto>> GetAll();
    }
}
