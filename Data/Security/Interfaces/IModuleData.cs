using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IModuleData
    {
        Task Delete(int id);
        Task<Modulo> Save(Modulo entity);
        Task Update(Modulo entity);
        Task<Modulo> GetById(int id);
        Task<IEnumerable<Modulo>> GetAll();

        Task UpdateModuloOrder(int id1, int id2);
    }
}
