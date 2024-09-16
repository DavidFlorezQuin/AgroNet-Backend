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
        Task<Treatment> Save(Treatment entity);
        Task Update(Treatment entity);
        Task<IEnumerable<Treatment>> GetAll();

        Task<Treatment> GetById(int id);
    }
}
