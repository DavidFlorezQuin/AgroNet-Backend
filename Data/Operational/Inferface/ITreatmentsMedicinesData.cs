using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface ITreatmentsMedicinesData : IData<TreatmentsMedicines>
    {
        Task<List<TreatmentMedicineDto>> GetTreatmentMedicineAsync(int farmId);
    }
}
