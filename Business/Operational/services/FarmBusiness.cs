using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class FarmBusiness : BaseBusiness<Farms, FarmDto>, IFarmBusiness
    {
        private readonly IFarmData _farmData; 
        public FarmBusiness(IMapper mapper, IFarmData data) : base(mapper, data)
        {
            _farmData = data; 
        }

        public async Task<IEnumerable<FarmDto>> MapFarmDto(int UserId)
        {
            var farms = await _farmData.GetFarmUser(UserId);

            var farmsDto = farms.Select(farm => new FarmDto
            {
                Name = farm.Name,
                Hectare = farm.Hectare,
                Description = farm.Description,
                Photo = farm.Photo,
                CityId = farm.CityId    
            }).ToList();

            return farmsDto; 
        }

    }
}
