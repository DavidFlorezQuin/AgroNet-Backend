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
                .Where(b => b.Animal.Lot.Farm.Id == farmId && b.Animal.Lot.Farm.state == true && b.deleted_at == null)
                .Select(b => new VaccineAnimalDto
                {
                    Id = b.Id,
                    state = b.state,
                    Animal = b.Animal.Name,
                    AnimalId = b.AnimalId,
                    DateApplied = b.DateApplied,
                    NextDose = b.NextDose,
                    Vaccine = b.Vaccines.Name,
                    VaccinesId = b.VaccinesId

                }).ToListAsync();

            return vaccineAnim; 
        }

        public virtual async Task<VaccineAnimals> Save(VaccineAnimals entity)
        {
            var dateApplied = entity.DateApplied = DateTime.Parse(DateTime.Today.ToString());

            var refuercePeriod = context.Vaccines.Where(v => v.Id == entity.VaccinesId)
                                                  .Select(v => v.RefuerzoPeriod)
                                                  .FirstOrDefault(); 

            if(refuercePeriod != null)
            {
                entity.NextDose = dateApplied.AddMonths(refuercePeriod); 
            }

            context.Set<VaccineAnimals>().Add(entity);
            await context.SaveChangesAsync();
            return entity; 





        }
  

    }
}
