using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface IRaceBusiness
    {
        Task<Race> Save(RaceDto entity);
        Task Detele(int id);
        Task<RaceDto> GetById(int id); 
        Task Update(int id, RaceDto entity);
        Task<IEnumerable<RaceDto>> GetAll(); 

    }
}
