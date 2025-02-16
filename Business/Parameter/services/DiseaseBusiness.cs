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
    public class DiseaseBusiness : BaseBusiness<Diseases, DiseaseDto>, IDiseaseBusiness
    {
        private readonly IDiseaseData _data;
        public DiseaseBusiness(IMapper mapper, IDiseaseData data): base(mapper, data) {
            _data = data; 
        }

        public async Task<List<DiseaseDto>> GetDiseaseAsync(int UsersId)
        {
            var enfermedad = await _data.GetDiseaseAsync(UsersId);

            if (enfermedad == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de enfermedad para el usuario proporcionado.");
            }

            return enfermedad;
        }
    }
}
