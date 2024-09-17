using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IInventoriesData
    {
        Task Delete(int id);
        Task<Inventories> Save(Inventories entity);
        Task Update(Inventories entity);
        Task<IEnumerable<Inventories>> GetAll();

        Task<Inventories> GetById(int id);
    }
}
