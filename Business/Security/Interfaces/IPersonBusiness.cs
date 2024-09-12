using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IPersonBusiness
    {
        Task Delete(int id);

        Task<Person> Save(PersonDto dto);

        Task<PersonDto> GetById(int id);

        Task Update(int id, PersonDto dto);

        Task<IEnumerable<PersonDto>> GetAll();

    }
}
