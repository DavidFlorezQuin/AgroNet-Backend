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
    public class FarmUserData : ABaseData<FarmUser>, IFarmUserData
    {
        public FarmUserData(AplicationDbContext context) : base(context) { }

        public async Task JoinFarm(Farms farms, int userId)
        {
            var userFarm = new FarmUser
            {
                UsersId = userId,
                FarmsId = farms.Id,
                state = false
            };
            context.FarmUsers.Add(userFarm);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsUserFarmExisting(int userId, Farms farms)
        {
            return await context.FarmUsers.AnyAsync(uf => uf.UsersId == userId && uf.FarmsId == farms.Id && uf.deleted_at == null);
        }

        public async Task<bool> UserIsOwner(int userId, Farms farms)
        {
            return await context.FarmUsers.AnyAsync(uf => uf.UsersId == userId && uf.FarmsId == farms.Id && uf.IsOwner == true);
        }

        public async Task<FarmUser> SearchUserFarm(int UserFarmId)
        {
            var userFarm = await context.FarmUsers.FindAsync(UserFarmId);
            return userFarm;
        }

        public async Task<List<FarmUserDto>> GetRequestUsers(int userId)
        {
            var farmUser = await context.FarmUsers
                .Include(fu => fu.Users)
                .Where(fu => fu.UsersId == userId
                && fu.IsOwner == false
                && fu.state == false
                && fu.deleted_at == null)
                .Select(fu => new FarmUserDto
                {
                    Id = fu.Id,
                    UsersId = fu.UsersId,
                    FarmsId = fu.FarmsId,
                    Farm = fu.Farms.Name,
                    Users = fu.Users.username

                }).ToListAsync();

            return farmUser;
        }

        public async Task<List<FarmUser>> GetFarmsByUserId(int UserId)
        {
            return await context.FarmUsers
                .Where(fu => fu.FarmsId == UserId
                && fu.IsOwner == true)
                .ToListAsync();
        }

        public async Task AcceptUserFarm(FarmUser farmUser)
        {
            farmUser.state = true;
            context.Update(farmUser);
            await context.SaveChangesAsync();
        }

    }
}
