using Entity.Dto.Operation;
using Entity.Dto.Parameter;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IAlertBusiness
    {
        Task<Alert> Save(AlertDto entity);
        Task Detele(int id);
        Task<AlertDto> GetById(int id);
        Task Update(int id, AlertDto entity);
        Task<IEnumerable<AlertDto>> GetAll();
    }
}
