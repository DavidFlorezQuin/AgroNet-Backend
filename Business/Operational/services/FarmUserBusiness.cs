using AutoMapper;
using Business.Exceptions;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Operational.services
{
    public class FarmUserBusiness : BaseBusiness<FarmUser, FarmUserDto>, IFarmUserBusiness
    {
        private readonly IFarmUserData _farmUserData;
        private readonly IFarmData _farmData;


        public FarmUserBusiness(IMapper mapper, IFarmUserData data, IFarmData farmData) : base(mapper, data)
        {

            _farmData = farmData;
            _farmUserData = data;
        }

        public async Task JoinFarm(string farmCode, int userId)
        {
            if (userId == 0)
            {
                throw new ZeroException("usario");
            }

            var farm = await _farmData.SearchFarmByCode(farmCode);



            if (farm == null)
            {
                throw new FarmNotCodeExceptions();
            }

            var isExisting = await _farmUserData.IsUserFarmExisting(userId, farm);

            var isOwner = await _farmUserData.UserIsOwner(userId, farm);


            if (isOwner)
            {
                throw new UserIsOwnerException();
            }

            if (isExisting)
            {
                throw new UserFarmRelationAlreadyExistsException();
            }

            await _farmUserData.JoinFarm(farm, userId);
        }

        public async Task AcceptUserFarm(int userFarmId)
        {
            if (userFarmId == 0)
            {
                throw new ZeroException("usuario finca");
            }
            var userFarm = await _farmUserData.SearchUserFarm(userFarmId);


            if (userFarm == null)
            {
                throw new UserFarmNotFoundException();
            }
            await _farmUserData.AcceptUserFarm(userFarm);
        }

        public async Task<List<FarmUserDto>> GetRequestUsers(int userId)
        {
            if(userId == 0)
            {
                throw new ZeroException("usuarios"); 
            }

            var listRequest = await _farmUserData.GetRequestUsers(userId);

            if(listRequest == null || !listRequest.Any())
            {
                throw new NoRequestUsersException();
            }
            return listRequest;
        }

        public async Task<List<FarmUserDto>> GetFarmsByUserId(int UserId)
        {
           var list =  await _farmUserData.GetFarmsByUserId(UserId);
            if (list == null || !list.Any())
            {
                throw new NoRequestUsersException();
            }
            return _mapper.Map<List<FarmUserDto>>(list);
        }

    }
}