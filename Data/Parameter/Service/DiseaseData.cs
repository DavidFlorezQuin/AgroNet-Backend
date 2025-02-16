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
    public class DiseaseData : ABaseData<Diseases>, IDiseaseData
    {
        public DiseaseData(AplicationDbContext context) : base(context) { }

        public async Task<List<DiseaseDto>> GetDiseaseAsync(int UsersId)
        {
            var diseases = await context.Diseases
                .Include(m => m.CategoryDiseases)
                .Select(m => new DiseaseDto
                {
                    Id = m.Id,
                    state = m.state,
                    Name = m.Name,
                    Description = m.Description,
                    CategoryDisieses = m.CategoryDiseases.Name,
                }).ToListAsync();
            return diseases;
        }

    }
}
