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
                    state = a.state
                }).ToListAsync();

            return animalDiagnostic; 
        }
    }
}
