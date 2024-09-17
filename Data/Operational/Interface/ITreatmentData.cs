using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface ITreatmentData
    {
        Task Delete(int id);
        Task<Treatments> Save(Treatments entity);
        Task Update(Treatments entity);
        Task<IEnumerable<Treatments>> GetAll();

        Task<Treatments> GetById(int id);
    }
}
