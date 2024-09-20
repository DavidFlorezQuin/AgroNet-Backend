using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data.Operational.services
{
    public class InseminationData : ABaseData<Inseminations>, IInseminationData
    {
        public InseminationData(AplicationDbContext context) : base(context) { }

        public virtual async Task<Inseminations> Save(Inseminations entity)
        {

            await ValidateInsamination(entity);
            await ValidateGenderAnimal(entity); 

            context.Set<Inseminations>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        private async Task ValidateGenderAnimal(Inseminations entity)
        {
            var AnimalId = entity.MotherId; 

            bool isMale = await context.Set<Animals>().AnyAsync(a => a.Id  == AnimalId && a.Gender == "Male");

            if (isMale)
            {
                throw new InvalidOperationException("El animal seleccionado para la inseminación no puede ser macho.");
            }
        }

        private async Task ValidateInsamination(Inseminations entity)
        {
            bool hasPendingInsemination = await context.Set<Inseminations>()
        .AnyAsync(i => i.MotherId == entity.MotherId && (i.state == true && i.Result != "PENDIENTE"));

            if (hasPendingInsemination)
            {
                throw new InvalidOperationException("El animal tiene una inseminación activa pendiente");
            }
        }
    }
}
