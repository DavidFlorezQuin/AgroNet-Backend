
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
    public class BirthData : ABaseData<Births>, IBirthData
    {
        public BirthData(AplicationDbContext context) : base(context) { }

        public async Task<List<BirthDto>> GetBirthAsync(int i)
        {
            var births = await context.Births
                .Where(b => b.deleted_at == null && b.Insemination.Mother.Lot.Farm.Id == i && b.Insemination.Mother.Lot.Farm.state == true)
                .Select(b => new BirthDto
                {
                    Id = b.Id,
                    Assistence = b.Assistence,
                    BirthWeight = b.BirthWeight,
                    Description = b.Description,
                    Result = b.Result,
                    InseminationId = b.InseminationId,
                    state = b.state, 
                    Created_at = b.created_at,
                    Insemination = b.Insemination.Mother.Name
                }).ToListAsync();

            return births;

        }
        public override async Task<Births> Save(Births entity)
        {
            entity.created_at = DateTime.Now;

            var insemination = await context.Inseminations
                .FirstOrDefaultAsync(i => i.Id == entity.InseminationId);

            if (insemination == null)
            {
                throw new Exception("Inseminación no encontrada.");
            }
            insemination.state = false;

            context.Inseminations.Update(insemination);
            await context.SaveChangesAsync();

            context.Births.Add(entity);
            await context.SaveChangesAsync();

            return entity;

        }
    }
}