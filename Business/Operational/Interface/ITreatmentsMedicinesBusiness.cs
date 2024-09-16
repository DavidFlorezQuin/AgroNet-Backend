﻿using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ITreatmentsMedicinesBusiness
    {
        Task Delete(int id);

        Task<TreatmentsMedicines> Save(TreatmentMedicineDto dto);

        Task<TreatmentMedicineDto> GetById(int id);

        Task Update(int id, TreatmentMedicineDto dto);

        Task<IEnumerable<TreatmentMedicineDto>> GetAll();
    }
}
