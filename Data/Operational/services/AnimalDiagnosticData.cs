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
    public class AnimalDiagnosticData : ABaseData<AnimalDiagnostics>, IAnimalDiagnosticData
    {

        private readonly AplicationDbContext _context;

        public AnimalDiagnosticData(AplicationDbContext context) : base(context) {
            _context = context; 
        }

        public override async Task<AnimalDiagnostics> Save(AnimalDiagnostics entity)
        {
            entity.IsBeingTreated = false;
            entity.DiseaseStatus = "REGISTRADA";
            entity.state = true;
            entity.created_at = DateTime.Now;

            context.AnimalDiagnostics.Add(entity); 
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task RegisterAlive(int animalDiagnosticId)
        {
            var diagnostic = await _context.AnimalDiagnostics.FindAsync(animalDiagnosticId);
            if (diagnostic == null)
            {
                throw new Exception("Diagnóstico no encontrado");
            }

            if (!diagnostic.state)
            {
                throw new Exception("Diagnóstico inactivo");
            }
            diagnostic.state = false;
            diagnostic.DiseaseStatus = "CURADA";

            if (diagnostic.IsBeingTreated)
            {
                var treatments = await _context.Treatments
                    .Where(t => t.AnimalDiagnosticsId == diagnostic.Id)
                    .ToListAsync();

                foreach (var treatment in treatments)
                {
                    treatment.state = false;

                }
                   _context.Treatments.UpdateRange(treatments);
                await _context.SaveChangesAsync();

            }

            _context.AnimalDiagnostics.Update(diagnostic); 
            await _context.SaveChangesAsync();
        }

        public async Task RegisterDead(int animalDiagnosticId)
        {
            var diagnostic = await context.AnimalDiagnostics.FindAsync(animalDiagnosticId);

            if (diagnostic == null)
            {
                throw new Exception("Diagnóstico no encontrado");
            }

            if (!diagnostic.state)
            {
                throw new Exception("Diagnóstico inactivo");
            }
            diagnostic.state = false;
            diagnostic.DiseaseStatus = "FALLECIMIENTO";

            if (diagnostic.IsBeingTreated)
            {
                var treatmens = await context.Treatments
                    .Where(t => t.AnimalDiagnosticsId == diagnostic.Id)
                    .ToListAsync();

                foreach (var treatment in treatmens)
                {
                    treatment.state = false;
                }
                context.Treatments.UpdateRange(treatmens);
                await _context.SaveChangesAsync();
    
            }

            var animal = await context.Animals.FindAsync(diagnostic.AnimalId);

            if (animal == null)
            {
                throw new Exception("Animal no encontrado"); 
            }
            animal.state = false;

            context.AnimalDiagnostics.Update(diagnostic);
            context.Animals.Update(animal);
            await context.SaveChangesAsync();
        }
        public async Task<List<AnimalDiagnosticDto>> GetAnimalDiagAsync(int IdFarm) {

            var animalDiagnostic = await _context.AnimalDiagnostics
                .Include(a => a.Animal)
                .Include(a => a.Users)
                .Where(b => b.deleted_at == null && b.Animal.Lot.Farm.Id == IdFarm && b.Animal.Lot.Farm.state == true)
                .Select(a => new AnimalDiagnosticDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Diagnosis = a.Diagnosis,
                    AnimalId = a.AnimalId,
                    Animal = a.Animal.Name,
                    UsersId = a.UsersId,
                    Users = a.Users.username,
                    state = a.state,
                    DiseaseStatus = a.DiseaseStatus,
                    IsBeingTreated = a.IsBeingTreated
                }).ToListAsync();

            return animalDiagnostic; 
        }


    }
}
