using Data.Security.Implementation;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IViewBusiness
    {
        Task Delete(int id);

        Task<ViewDto> GetById(int id);

        Task Update(int id, ViewDto entity);

        Task<Views> Save(ViewDto entity);

        Task<IEnumerable<ViewDto>> GetAll();

        Task<IEnumerable<ViewDto>> ViewsByRole(int roleId);

    }
}
