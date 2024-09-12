using Data.Security.Implementation;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IUserRoleBusiness
    {
        Task Update(int id, UserRoleDto entity);
        Task Delete(int id);
        //Task<List<UserRoleDto>> GetAll();
        Task<UserRole> Save(UserRoleDto entity);

        Task<UserRoleDto> GetById(int id);
        Task<IEnumerable<UserRoleDto>> GetAll();


    }
}
