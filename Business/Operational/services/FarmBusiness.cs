using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Operational.services
{
    public class FarmBusiness : BaseBusiness<Farms, FarmDto>, IFarmBusiness
    {
        private readonly IFarmData _farmData;
        private readonly IFarmUserBusiness _farmUserBusiness;
        public FarmBusiness(IMapper mapper, IFarmData data, IFarmUserBusiness business) : base(mapper, data)
        {
            _farmData = data;
            _farmUserBusiness = business; 
        }

        public async Task<FarmDto> SaveAsync(FarmUserBodyDto farmUserBodyDto )
        {
            farmUserBodyDto.farmDto.Code = GenerateFarmCode();

            var entity = _mapper.Map<Farms>(farmUserBodyDto.farmDto);

            var saveFarm = await _farmData.SaveAsync(entity, farmUserBodyDto.UserId);

            var farmUser = new FarmUserDto
            {
                FarmsId = saveFarm.Id,
                UsersId = farmUserBodyDto.UserId,
                state = true,
                IsOwner = true
            };

             await _farmUserBusiness.Save(farmUser);


            return _mapper.Map<FarmDto>(entity);

        } 
        private string GenerateFarmCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            var part1 = new string(Enumerable.Range(1, 5).Select(_ => chars[random.Next(chars.Length)]).ToArray());
            var part2 = new string(Enumerable.Range(1, 5).Select(_ => chars[random.Next(chars.Length)]).ToArray());

            return $"{part1}-{part2}";
        }

    }
}
