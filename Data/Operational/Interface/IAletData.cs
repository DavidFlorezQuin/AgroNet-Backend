using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IAletData
    {
        Task Delete(int id);
        Task<Alert> Save(Alert entity);
        Task Update(Alert entity);
        Task<IEnumerable<Alert>> GetAll();

        Task<Alert> GetById(int id);

    }
}
