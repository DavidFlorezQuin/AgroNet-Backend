using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ICategorySuppliesData
    {
        Task Delete(int id);
        Task<CategorySupplies> Save(CategorySupplies entity);
        Task Update(CategorySupplies entity);
        Task<IEnumerable<CategorySupplies>> GetAll();

        Task<CategorySupplies> GetById(int id);
    }
}
