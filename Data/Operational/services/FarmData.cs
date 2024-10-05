    using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class FarmData : ABaseData<Farms>, IFarmData
    {
        public FarmData(AplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<Farms>> GetFarmUser(int UserId)
        {
            var query = from farm in context.Farms
                        join farmUser in context.FarmUsers
                        on farm.Id equals farmUser.UsersId
                        where farmUser.UsersId == UserId
                        select farm; 
            return await query.ToListAsync();
        }


    }
}
