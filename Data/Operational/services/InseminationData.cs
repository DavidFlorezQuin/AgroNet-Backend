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
using static Dapper.SqlMapper;

namespace Data.Operational.services
{
    public class InseminationData : ABaseData<Inseminations>, IInseminationData
    {

        public override async Task<Inseminations> Save(Inseminations entity)
        {
            entity.created_at = DateTime.Now;
            entity.Result = "PENDIENTE";
            entity.IsAborted = false;
            entity.EstimatedBirthDate = entity.created_at.AddMonths(9);
            
            context.Inseminations.Add(entity); 
            await context.SaveChangesAsync();
            return entity; 
        }
        
        public InseminationData(AplicationDbContext context) : base(context) { }

        public async Task<bool> ValidateGenderAnimal(Inseminations entity)
        {
            var AnimalId = entity.MotherId; 

            return await context.Set<Animals>().AnyAsync(a => a.Id  == AnimalId && a.Gender == "Male");
        }

        public async Task<bool> ValidateInsamination(Inseminations entity)
        {
            return await context.Set<Inseminations>()
        .AnyAsync(i => i.MotherId == entity.MotherId && (i.state == true && i.Result != "PENDIENTE"));

        }



        public async Task<List<InseminationDto>> GetInseminationAsync(int farmId)
        {
            var Insemination = await context.Inseminations
                .Include(i => i.Semen)
                .Include(i => i.Mother)
                .Where(i => i.deleted_at == null && i.Mother.Lot.Farm.Id == farmId && i.Mother.Lot.Farm.state == true) 
                .Select(i => new InseminationDto
                {
                    Id = i.Id,
                    EstimatedBirthDate = i.EstimatedBirthDate,
                    Mother = i.Mother.Name,
                    Description = i.Description,
                    SemenId = i.SemenId,
                    MotherId = i.MotherId,
                    Semen = i.Semen.Name,
                    IsAborted = i.IsAborted,
                    Result = i.Result,
                    InseminationType = i.InseminationType,
                    state = i.state
                }).ToListAsync();

            return Insemination; 
        }
        public async Task<List<InseminationDto>> GetInseminationActive(int farmId)
        {
            var Insemination = await context.Inseminations
                .Include(i => i.Semen)
                .Include(i => i.Mother)
                .Where(i => i.deleted_at == null && i.Mother.Lot.Farm.Id == farmId && i.state == true && i.Result == "EXITOSO") 
                .Select(i => new InseminationDto
                {
                    Id = i.Id,
                    EstimatedBirthDate = i.EstimatedBirthDate,
                    Mother = i.Mother.Name,
                    Description = i.Description,
                    SemenId = i.SemenId,
                    MotherId = i.MotherId,
                    Semen = i.Semen.Name,
                    IsAborted = i.IsAborted,
                    Result = i.Result,
                    InseminationType = i.InseminationType,
                    state = i.state
                }).ToListAsync();

            return Insemination; 
        }

        public void RegisterAbortion(int inseminationId)
        {
            var insemination = context.Inseminations.Find(inseminationId);
            if (insemination == null)
            {
                throw new Exception("Inseminación no encontrada"); 
            }

            if(insemination.state == false)
            {
                throw new Exception("Inseminación inactiva"); 
            }
            insemination.Result = "ABORTO";
            insemination.IsAborted = true;
            insemination.state = false; 

            context.Inseminations.Update(insemination); 
            context.SaveChanges(); 
        }

        public void RegisterBorn(int inseminationId)
        {
            var insemination = context.Inseminations.Find(inseminationId);
            if (insemination == null)
            {
                throw new Exception("Inseminación no encontrada");
            }

            if (insemination.state == false)
            {
                throw new Exception("Inseminación inactiva");
            }
            insemination.Result = "EXITOSO";
            insemination.IsAborted = false;

            context.Inseminations.Update(insemination);
            context.SaveChanges();
        }
    }
}
