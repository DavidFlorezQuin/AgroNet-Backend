using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IModuleBusiness
    {
        Task UpdateModuloOrder(int id1, int id2);

        Task Delete(int id);

        Task<Modulo> Save(ModuloDto dto);

        Task Update(int id, ModuloDto dto);

        Task<ModuloDto> GetById(int id);

        Task<IEnumerable<ModuloDto>> GetAll();

    }
}
