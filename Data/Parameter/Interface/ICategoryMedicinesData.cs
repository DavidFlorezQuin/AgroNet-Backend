using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ICategoryMedicinesData
    {
        Task Delete(int id);
        Task<CategoryMedicines> Save(CategoryMedicines entity);
        Task Update(CategoryMedicines entity);
        Task<IEnumerable<CategoryMedicines>> GetAll();
        Task<CategoryMedicines> GetById(int id);
    }
}
