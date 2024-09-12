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
    public interface ICityBusiness
    {
        Task Delete(int id);

        Task<City> Save(CityDto entity);
        Task<CityDto> GetById(int id);

        Task Update(int id, CityDto entity);

        Task<IEnumerable<CityDto>> GetAll();



    }
}
