using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class AnimalData : ABaseData<Animals>, IAnimalData
    {
        public AnimalData(AplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<Animals>> GetAnimalsFarm(int farmId)
        {
            var query = from animals in context.Animals
                        join lots in context.Lots
                        on animals.LotId equals lots.Id
                        join farm in context.Farms
                        on lots.FarmId equals farm.Id
                        where farm.Id == farmId
                        select animals; 
            return await query.ToListAsync(); 
        }
    
    
    }
}
