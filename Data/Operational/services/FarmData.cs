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

        public async Task<List<FarmDto>> GetFarmAsync(int userId)
        {
            var farm = await context.Farms
                .Include(a => a.City)
        .Where(a => context.FarmUsers.Any(fu => fu.UsersId == userId && fu.IsOwner == true && fu.FarmsId == a.Id) && a.deleted_at == null)
                .Select(a => new FarmDto
                {
                    Id = a.Id,
                    CityId = a.CityId,
                    City = a.City.Name,
                    Hectare = a.Hectare,
                    Description = a.Description,
                    Name = a.Name,
                    Code = a.Code,
                    Photo = a.Photo,
                    state = a.state
                }).ToListAsync();
            return farm; 
        }

        public async Task<Farms> SaveAsync(Farms farms, int userId) {

            farms.state = true;
            farms.created_at = DateTime.Now;

            context.Farms.Add(farms);
            await context.SaveChangesAsync();
            return farms;

        }

        public async Task<Farms> SearchFarmByCode(string codeFarm)
        {
            var farm = await context.Farms.
                FirstOrDefaultAsync(f => f.Code == codeFarm);
            return farm;
        }

    }
}
