using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Interface
{
    public interface ICountryData
    {
        Task Delete(int id);
        Task<Country> Save(Country entity);
        Task Update(Country entity);
        Task<Country> GetById(int id);
        Task<IEnumerable<Country>> GetAll();

    }
}
