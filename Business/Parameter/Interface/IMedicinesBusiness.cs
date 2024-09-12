using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface IMedicinesBusiness
    {
        Task<Medicines> Save(IMedicinesBusiness entity);
        Task Delete(int id);
        Task Update(int id, IMedicinesBusiness entity);
        Task <IEnumerable<IMedicinesBusiness>> GetAll();
        Task<IMedicinesBusiness> GetById(int id);


    }
}
