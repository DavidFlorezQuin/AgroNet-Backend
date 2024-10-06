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
        public async Task<List<AnimalDiagnosticDto>> GetAnimalDiagAsync() {

            var animalDiagnostic = await _context.AnimalDiagnostics
                .Include(a => a.Animal)
                .Include(a => a.Users)
                .Select(a => new AnimalDiagnosticDto
                {
                    Id = a.Id,
                    Diagnosis = a.Diagnosis,
                    AnimalId = a.AnimalId,
                    Animal = a.Animal.Name,
                    UsersId = a.UsersId,
                    Users = a.Users.username
                }).ToListAsync();

            return animalDiagnostic; 
        }
    }
}
