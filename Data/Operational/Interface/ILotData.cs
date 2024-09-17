using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface ILotData
    {
        Task Delete(int id);
        Task<Lots> Save(Lots entity);
        Task Update(Lots entity);
        Task<IEnumerable<Lots>> GetAll();

        Task<Lots> GetById(int id);
    }
}
