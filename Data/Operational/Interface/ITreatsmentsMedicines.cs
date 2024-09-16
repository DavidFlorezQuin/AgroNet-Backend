using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface ITreatsmentsMedicines
    {
        Task Delete(int id);
        Task<TreatmentsMedicines> Save(TreatmentsMedicines entity);
        Task Update(TreatmentsMedicines entity);
        Task<IEnumerable<TreatmentsMedicines>> GetAll();

        Task<TreatmentsMedicines> GetById(int id);
    }
}
