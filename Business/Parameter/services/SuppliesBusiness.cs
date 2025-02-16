using AutoMapper;
using Business.Operational.services;
using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class SuppliesBusiness : BaseBusiness<Supplies, SuppliesDto>, ISuppliesBusiness
    {
        private readonly ISuppliesData _data;
        public SuppliesBusiness(IMapper mapper, ISuppliesData data) : base(mapper, data)
        {
            _data = data;
        }

        public async Task<List<SuppliesDto>> GetSuppliesAsync(int userId)
        {
            var supplies = await _data.GetSuppliesAsync(userId);

            if (supplies == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro para el usuario proporcionado."); 
            }

            return supplies;
        }
    }
}

