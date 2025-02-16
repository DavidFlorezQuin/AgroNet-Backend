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
    public class SuppliesData: ABaseData<Supplies>, ISuppliesData
    {
        public SuppliesData(AplicationDbContext context) : base(context) { }

        public async Task<List<SuppliesDto>> GetSuppliesAsync(int userId)
        {
            var supplies = await context.Supplies
                .Include(s => s.CategorySupplies)
                .Where(s => s.FarmsId == userId)
                .Select(s => new SuppliesDto
                {
                    Id = s.Id,
                    state = s.state,
                    Name = s.Name,
                    Description = s.Description,
                    CategorySupplies = s.CategorySupplies.Name
                })
                .ToListAsync();

            return supplies; 
        }
    }
}
