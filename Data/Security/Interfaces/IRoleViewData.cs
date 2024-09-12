using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IRoleViewData
    {
        Task Delete(int id);
        Task<RoleView> Save(RoleView entity);
        Task Update(RoleView entity);

        Task<RoleView> GetById(int id);
        Task<IEnumerable<RoleView>> GetAll();
        Task<IEnumerable<RoleView>> ViewsByRole(int id);

    }
}
