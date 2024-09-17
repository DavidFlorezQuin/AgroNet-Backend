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
        Task<Alerts> Save(Alerts entity);
        Task Update(Alerts entity);
        Task<IEnumerable<Alerts>> GetAll();

        Task<Alerts> GetById(int id);

    }
}
