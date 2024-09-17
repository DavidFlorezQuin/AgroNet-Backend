using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IBusiness<TEntityDto>
    {
        Task<TEntityDto> GetById(int id);
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> Save(TEntityDto entity);
        Task Update(int id, TEntityDto entity);
        Task Delete(int id);
    }
}
