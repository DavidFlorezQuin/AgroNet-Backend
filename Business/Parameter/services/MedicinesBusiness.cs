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
    public class MedicinesBusiness : BaseBusiness<Medicines, MedicinesDto>, IMedicinesBusiness
    {
        private readonly IMedicinesData _data;

        public MedicinesBusiness(IMapper mapper, IMedicinesData data) : base (mapper, data ){
            _data = data; 
        }
        public async Task<List<MedicinesDto>> GetMedicineAsync(int UsersId)
        {
            var medicine = await _data.GetMedicineAsync(UsersId);

            if (medicine == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de medicina para el usuario proporcionado.");
            }

            return medicine;
        }
    }
}
