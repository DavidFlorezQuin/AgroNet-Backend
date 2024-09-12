using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IViewData
    {
        Task Delete(int id);
        Task<Views> Save(Views entity);
        Task Update(Views entity);

        Task<Views> GetById(int id);
        Task<IEnumerable<Views>> GetAll();

        Task<IEnumerable<Views>> ViewsByRole(int id);
    }
}
