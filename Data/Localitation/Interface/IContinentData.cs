using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Interface
{
    public interface IContinentData
    {
        Task Delete(int id);
        Task<Continent> Save(Continent entity);
        Task Update(Continent entity);
        Task<Continent> GetById(int id);
        Task<IEnumerable<Continent>> GetAll();



    }
}
