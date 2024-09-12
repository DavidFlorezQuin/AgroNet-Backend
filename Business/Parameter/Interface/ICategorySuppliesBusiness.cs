using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface ICategorySuppliesBusiness
    {
        Task<CategorySupplies> Save(CategorySuppliesDto entity);
        Task Delete(int id);
        Task Update(int id, CategorySuppliesDto entity);
        Task<IEnumerable<CategorySuppliesDto>> GetAll();
        Task<CategorySuppliesDto> GetById(int id);
    }
}
