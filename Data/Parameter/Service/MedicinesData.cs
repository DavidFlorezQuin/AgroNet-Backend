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
    public class MedicinesData : ABaseData<Medicines>, IMedicinesData
    {
        public MedicinesData(AplicationDbContext context) : base(context) { }

        public async Task<List<MedicinesDto>> GetMedicineAsync(int UsersId)
        {
            var medicine = await context.Medicines
                .Include(m => m.CategoryMedicines)
                .Select(m => new MedicinesDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Administration = m.Administration,
                    CategoryMedicines = m.CategoryMedicines.Name
                }).ToListAsync();
            return medicine;
        }

    }
}
