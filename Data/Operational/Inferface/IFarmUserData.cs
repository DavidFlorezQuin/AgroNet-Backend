using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IFarmUserData : IData<FarmUser>
    {
        Task<bool> IsUserFarmExisting(int userId, Farms farms);
        Task JoinFarm(Farms farms, int userId);
        Task<FarmUser> SearchUserFarm(int UserFarmId);
        Task AcceptUserFarm(FarmUser farmUser);
        Task<List<FarmUserDto>> GetRequestUsers(int farmId);
        Task<List<FarmUser>> GetFarmsByUserId(int UserId);
        Task<bool> UserIsOwner(int userId, Farms farms); 
    }
}
