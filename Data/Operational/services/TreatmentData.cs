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
    public class TreatmentData : ABaseData<Treatments>, ITreatmentsData
    {
        public TreatmentData(AplicationDbContext context) : base(context) { }

        public override async Task<Treatments> Save(Treatments entity){



            entity.state = true;
            entity.created_at = DateTime.Now;
            entity.Result = "ENPROCESO";

            var diagnostic = await context.AnimalDiagnostics.FindAsync(entity.AnimalDiagnosticsId);

            if (diagnostic == null)
            {
                throw new Exception("Diagnóstico no encontrado");
            }

            if (!diagnostic.state)
            {
                throw new Exception("Diagnóstico inactivo");
            }

            diagnostic.IsBeingTreated = true;
            diagnostic.DiseaseStatus = "ENPROCESO"; 

            context.AnimalDiagnostics.Update(diagnostic);
            context.Treatments.Add(entity);

            await context.SaveChangesAsync();
            return entity; 
        }


        public async Task<List<TreatmentDto>> GetTreatmentAsync(int farmId)
        {
            var treatment = await context.Treatments
                .Include(b => b.AnimalDiagnostics)
                .Where(b => b.AnimalDiagnostics.Animal.Lot.Farm.Id == farmId && b.AnimalDiagnostics.Animal.Lot.Farm.state == true && b.deleted_at == null)
                .Select(b => new TreatmentDto
                {
                    Id = b.Id,
                    Description = b.Description,
                    AnimalDiagnostics = b.AnimalDiagnostics.Name,
                    FinishiedDate = b.FinishiedDate,
                    StartDate = b.StartDate,
                    state = b.state,
                    Name = b.Name
                }).ToListAsync();
            return treatment; 
        }
    }
}
