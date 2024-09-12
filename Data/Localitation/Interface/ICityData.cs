using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Interface
{
    public interface ICityData
    {
        Task Delete(int id);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAll();

    }
}
