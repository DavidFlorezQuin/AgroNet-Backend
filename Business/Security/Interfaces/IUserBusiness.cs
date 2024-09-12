using Data.Security.Implementation;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<UserDto> GetById(int id);
        Task<Users> Save(UserDto entity);
        Task Update(int id, UserDto entity);
        Task<IEnumerable<UserDto>> GetAll();
        Task<List<RoleMenuDto>> MapRolesToMenu(int userId);
        Task<UserDto> LoginAsync(LoginDto login);


    }
}
