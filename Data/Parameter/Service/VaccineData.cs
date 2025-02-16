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
    public class VaccineData : ABaseData<Vaccines>, IVaccineData
    {
        public VaccineData(AplicationDbContext context) : base(context) {}

        public async Task<List<VaccineDto>> GetVaccineAsync(int UsersId)
        {
            var vaccine = await context.Vaccines
                .Select(v => new VaccineDto
                {
                    Id = v.Id,
                    state = v.state,
                    Name = v.Name,
                    Description = v.Description,
                    DosesRequired = v.DosesRequired,
                    RefuerzoPeriod = v.RefuerzoPeriod,
                    Contraindications = v.Contraindications,
                    TypeVaccine = v.TypeVaccine,
                })
                .ToListAsync();

            return vaccine;
        }
    }
}
