using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<Users> Save(Users entity);
        Task Update(Users entity);
        Task<Users> GetById(int id);
        Task<IEnumerable<Users>> GetDataTable(); 
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetUserAsync(string username, string password);
        Task<List<Role>> GetRolesForUser(int userId);


    }
}
