using Data.Operational.Inferface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface IMedicinesData : IData<Medicines>
    {
        Task<List<MedicinesDto>> GetMedicineAsync(int UsersId);

    }
}
