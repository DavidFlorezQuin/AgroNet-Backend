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
        Task<Sales> Save(Sales entity);
        Task Update(Sales entity);
        Task<IEnumerable<Sales>> GetAll();

        Task<Sales> GetById(int id);
    }
}
