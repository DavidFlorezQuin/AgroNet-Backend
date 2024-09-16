using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface ISuppliesData
    {
        Task Delete(int id);
        Task<Supplies> Save(Supplies entity);
        Task Update(Supplies entity);
        Task<IEnumerable<Supplies>> GetAll();

        Task<Supplies> GetById(int id);
    }
}
