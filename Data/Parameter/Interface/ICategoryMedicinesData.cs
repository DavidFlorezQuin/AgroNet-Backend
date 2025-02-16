using Data.Operational.Inferface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ICategoryMedicinesData : IData<CategoryMedicines>
    {
        Task<List<CategoryMedicinesDto>> GetCategoryMedicinesAsync(int UsersId);

    }
}
