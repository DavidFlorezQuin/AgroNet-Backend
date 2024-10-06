    using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                        on farm.Id equals farmUser.FarmsId // Cambié de farmUser.UsersId a farmUser.FarmId para corregir la relación
                        where farmUser.UsersId == UserId
                        select farm; 
            return await query.ToListAsync();
        }

        public async Task<List<FarmDto>> GetFarmAsync(int userId)
        {
            var farm = await context.Farms
                .Include(a => a.City)
                .Where(a => context.FarmUsers.Any(fu => fu.FarmsId == a.Id && fu.UsersId == userId))
                .Select(a => new FarmDto
                {
                    Id = a.Id,
                    CityId = a.CityId,
                    City = a.City.Name,
                    Hectare = a.Hectare,
                    Description = a.Description,
                    Name = a.Name,
                    Photo = a.Photo,
                    state = a.state
                }).ToListAsync();
            return farm; 
        }




    }
}
