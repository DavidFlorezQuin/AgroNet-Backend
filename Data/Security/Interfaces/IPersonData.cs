using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IPersonData
    {
        Task Delete(int id);
        Task<Person> Save(Person entity);
        Task Update(Person entity);
        Task<Person> GetById(int id);
        Task<IEnumerable<Person>> GetAll();
    }
}
