using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IProductionData
    {
        Task Delete(int id);
        Task<Production> Save(Production entity);
        Task Update(Production entity);
        Task<IEnumerable<Production>> GetAll();

        Task<Production> GetById(int id);
    }
}
