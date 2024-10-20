using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class TreatmentsMedicinesBusiness : BaseBusiness<TreatmentsMedicines, TreatmentMedicineDto>, ITreatmentsMedicinesBusiness
    {
        private readonly ITreatmentsMedicinesData _data;
        public TreatmentsMedicinesBusiness(IMapper mapper, ITreatmentsMedicinesData data) : base(mapper, data)
        {
            _data = data; 
        }
            public async Task<List<TreatmentMedicineDto>> GetMedicineForTreatments(int treatmentId)
            {

            if(treatmentId == 0)
            {
                throw new ArgumentException("Tratamiento no referenciado"); 
            }

            return await _data.GetMedicineForTreatments(treatmentId); 
            }
    }
}
