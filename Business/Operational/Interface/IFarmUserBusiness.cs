using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IFarmUserBusiness : IBusiness<FarmUserDto>
    {
        Task JoinFarm(string farmCode, int userId);
        Task AcceptUserFarm(int userFarmId);
        Task<List<FarmUserDto>> GetRequestUsers(int farmId);
        Task<List<FarmUserDto>> GetFarmsByUserId(int UserId);

    }
}
