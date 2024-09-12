using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<RoleView> Save(RoleViewDto dto);

        Task<RoleViewDto> GetById(int id);

        Task Update(int id, RoleViewDto dto);

        Task <IEnumerable<RoleViewDto>> GetAll();

    }
}
