using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface ISaleData
    {
        Task Delete(int id);
        Task<Sale> Save(Sale entity);
        Task Update(Sale entity);
        Task<IEnumerable<Sale>> GetAll();

        Task<Sale> GetById(int id);
    }
}
