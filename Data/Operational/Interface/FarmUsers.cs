using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface FarmUsers
    {
        Task Delete(int id);
        Task<Farms> Save(Alerts entity);
        Task Update(Farms entity);
        Task<IEnumerable<Farms>> GetAll();

        Task<Farms> GetById(int id);
    }
}
