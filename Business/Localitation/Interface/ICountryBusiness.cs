using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.Interface
{
    public interface ICountryBusiness
    {
        Task Delete(int id);

        Task<Country> Save(CountryDto entity);
        Task<CountryDto> GetById(int id);

        Task Update(int id, CountryDto entity);
        Task<IEnumerable<CountryDto>> GetAll();

    }
}
