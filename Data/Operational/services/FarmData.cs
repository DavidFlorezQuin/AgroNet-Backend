﻿    using Data.Operational.Inferface;
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
                .Where(a => context.FarmUsers.Any(fu => fu.FarmsId == a.Id && fu.UsersId == userId) && a.deleted_at == null)
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
