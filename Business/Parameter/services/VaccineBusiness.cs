using AutoMapper;
using Business.Operational.services;
using Business.Parameter.Interface;
using Data.Operational.Inferface;
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
    public class VaccineBusiness : BaseBusiness<Vaccines, VaccineDto>, IVaccineBusiness
    {
        private readonly IVaccineData _data; 
        public VaccineBusiness(IMapper mapper, IVaccineData data) : base(mapper, data) { }

        public async Task<List<VaccineDto>> GetVaccineAsync(int UsersId)
        {

            var vaccine = await _data.GetVaccineAsync(UsersId);

            if(vaccine == null)
            {
                throw new InvalidOperationException("No se encontró ninguna vacuna para el usuario proporcionado.");
            }
            return vaccine; 
        }
    }
}
