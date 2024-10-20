using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class AnimalSalesBusiness : BaseBusiness<AnimalSales, AnimalSaleDto>, IAnimalSaleBusiness
    {
        private readonly IAnimalSaleData _data;
        public AnimalSalesBusiness(IMapper mapper, IAnimalSaleData animalData) : base(mapper, animalData)
        {
            _data = animalData;
        }


        public async Task<List<AnimalSaleDto>> GetAnimalSaleAsync(int farmId)
        {
            if (farmId == 0)
            {
                throw new Exception("Finca no asociada");
            }
            return await _data.GetAnimalSaleAsync(farmId);
        }
    }
}
