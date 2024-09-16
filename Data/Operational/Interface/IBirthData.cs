using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IBirthData
    {
        Task Delete(int id);
        Task<Birth> Save(Birth entity);
        Task Update(Birth entity);
        Task<IEnumerable<Birth>> GetAll();

        Task<Birth> GetById(int id);
    }
}
