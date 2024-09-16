using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IBirthBusiness
    {
        Task<Birth> Save(BirthDto entity);
        Task Detele(int id);
        Task<BirthDto> GetById(int id);
        Task Update(int id, BirthDto entity);
        Task<IEnumerable<BirthDto>> GetAll();
    }
}
