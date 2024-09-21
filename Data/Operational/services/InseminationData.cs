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
    }
}
