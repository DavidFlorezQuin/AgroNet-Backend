using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface ICategoryMedicinesBusiness
    {
        Task<CategoryMedicines> Save(CategoryMedicinesDto entity);
        Task Delete(int id);
        Task Update(int id, CategoryMedicinesDto entity);
        Task<IEnumerable<CategoryMedicinesDto>> GetAll();
        Task<CategoryMedicinesDto> GetById(int id);
    }
}
