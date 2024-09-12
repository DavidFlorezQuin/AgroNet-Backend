using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IUserRoleData
    {

        Task<UserRole> Save(UserRole entity);
        Task<UserRole> GetById(int id);
        Task Update(UserRole entity);
        Task Delete(int id);

        Task<IEnumerable<UserRole>> GetAll();

        Task<IEnumerable<RoleDto>> GetRoleByUser(int id);
    }
}
