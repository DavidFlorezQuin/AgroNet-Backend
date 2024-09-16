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
        Task<Insemination> Save(Insemination entity);
        Task Update(Insemination entity);
        Task<IEnumerable<Insemination>> GetAll();

        Task<Insemination> GetById(int id);
    }
}
