﻿using Data.Operational.Inferface;
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

        public async Task<IEnumerable<Animals>> GetAnimalsInsemination(int farmId)
        {
            var query = from animals in context.Animals
                        join lots in context.Lots
                        on animals.LotId equals lots.Id
                        join farm in context.Farms
                        on lots.FarmId equals farm.Id
                        join insemination in context.Inseminations
                        on animals.Id equals insemination.MotherId
                        where farm.Id == farmId && farm.state == true
                        select animals; 
                        return await query.ToListAsync();
        }

        public async Task<List<InseminationDto>> GetInseminationAsync(int farmId)
        {
            var Insemination = await context.Inseminations
                .Include(i => i.Semen)
                .Include(i => i.Mother)
                .Where(i => i.deleted_at == null && i.Mother.Lot.Farm.Id == farmId && i.Mother.Lot.Farm.state == true) // Filtra por farmId y estado activo de la finca
                .Select(i => new InseminationDto
                {
                    Id = i.Id,
                    Mother = i.Mother.Name,
                    Description = i.Description,
                    SemenId = i.SemenId,
                    MotherId = i.MotherId,
                    Semen = i.Semen.Name,
                    Result = i.Result,
                    InseminationType = i.InseminationType,
                    state = i.state
                }).ToListAsync();

            return Insemination; 
        }
    }
}
