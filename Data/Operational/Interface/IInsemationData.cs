using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IInsemationData
    {
        Task Delete(int id);
        Task<Inseminations> Save(Inseminations entity);
        Task Update(Inseminations entity);
        Task<IEnumerable<Inseminations>> GetAll();

        Task<Inseminations> GetById(int id);
    }
}
