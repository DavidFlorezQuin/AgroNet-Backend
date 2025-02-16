using AutoMapper;
using Business.Operational.services;
using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class CategoryMedicinesBusiness : BaseBusiness<CategoryMedicines, CategoryMedicinesDto>, ICategoryMedicinesBusiness
    {
        private readonly ICategoryMedicinesData _data; 
        public CategoryMedicinesBusiness(IMapper mapper, ICategoryMedicinesData data) : base(mapper, data) { _data = data; }

        public async Task<List<CategoryMedicinesDto>> GetCategoryMedicinesAsync(int UsersId)
        {
            var obj = await _data.GetCategoryMedicinesAsync(UsersId);

            if (obj == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de categoría para el usuario proporcionado.");
            }

            return obj;
        }
    }
}
