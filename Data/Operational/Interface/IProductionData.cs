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
        Task<Productions> Save(Productions entity);
        Task Update(Productions entity);
        Task<IEnumerable<Productions>> GetAll();

        Task<Productions> GetById(int id);
    }
}
