using Data.Operational.services;
using Data.Parameter.Interface;
using Entity.Context;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategoryMedicinesData : ABaseData<CategoryMedicines>, ICategoryMedicinesData
    {
        public CategoryMedicinesData(AplicationDbContext context) : base(context) { }

        public async Task<List<CategoryMedicinesDto>> GetCategoryMedicinesAsync(int UsersId)
        {
            var categories = await context.CategoryMedicines
                .Select(m => new CategoryMedicinesDto
                {
                    Id = m.Id,
                    state = m.state,
                    Name = m.Name,
                    Description = m.Description
                }).ToListAsync();

            return categories;
        }

    }
}
