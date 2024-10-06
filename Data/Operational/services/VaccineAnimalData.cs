using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class VaccineAnimalData : ABaseData<VaccineAnimals>, IVaccineAnimalData
    {
        public VaccineAnimalData(AplicationDbContext context) : base(context) { }

        public async Task<List<VaccineAnimalDto>> GetVaccineAnimalAsync(int farmId)
        {
            var vaccineAnim = await context.VaccineAnimals
                .Include(b => b.Vaccines)
                .Include(b => b.Animal)
                .Where(b => b.Animal.Lot.Farm.Id == farmId && b.Animal.Lot.Farm.state == true)
                .Select(b => new VaccineAnimalDto
                {
                    Id = b.Id,
                    state = b.state,
                    Animal = b.Animal.Name,
                    AnimalId = b.AnimalId,
                    DateApplied = b.DateApplied,
                    NextDose = b.NextDose,
                    Vaccine = b.Vaccines.Name,
                    VaccineId = b.VaccinesId

                }).ToListAsync();

            return vaccineAnim; 
        }

    }
}
