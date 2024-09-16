using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IFarmData
    {
        Task Delete(int id);
        Task<Farm> Save(Farm entity);
        Task Update(Farm entity);
        Task<IEnumerable<Farm>> GetAll();

        Task<Farm> GetById(int id);
    }
}
